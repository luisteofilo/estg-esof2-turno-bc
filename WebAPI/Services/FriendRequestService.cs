using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class FriendRequestService
    {
        private readonly ApplicationDbContext _context;

        public FriendRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendFriendRequestAsync(Guid requesterId, Guid receiverId)
        {
            var friendRequest = new FriendRequest
            {
                RequestId = Guid.NewGuid(),
                RequesterId = requesterId,
                ReceiverId = receiverId,
                Status = FriendRequestState.PENDING,
                CreatedAt = DateTime.UtcNow
            };

            _context.FriendRequests.Add(friendRequest);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptFriendRequestAsync(Guid requestId)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(requestId);
            if (friendRequest == null)
            {
                throw new Exception("Friend request not found");
            }

            friendRequest.Status = FriendRequestState.ACCEPTED;

            var friendship = new Friendship
            {
                FriendshipId = Guid.NewGuid(),
                UserId1 = friendRequest.RequesterId,
                UserId2 = friendRequest.ReceiverId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Friendships.Add(friendship);
            await _context.SaveChangesAsync();
        }

        public async Task RejectFriendRequestAsync(Guid requestId)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(requestId);
            if (friendRequest == null)
            {
                throw new Exception("Friend request not found");
            }

            friendRequest.Status = FriendRequestState.REQUESTED;
            await _context.SaveChangesAsync();
        }

        public async Task<List<FriendRequest>> GetFriendRequestsForUserAsync(Guid userId)
        {
            return await _context.FriendRequests
                .Where(fr => fr.ReceiverId == userId && fr.Status == FriendRequestState.PENDING)
                .ToListAsync();
        }
        
        public FriendRequestState? GetFriendRequestState(Guid requesterId, Guid receiverId)
        {
            var friendRequest = _context.FriendRequests
                .FirstOrDefault(fr => fr.RequesterId == requesterId && fr.ReceiverId == receiverId);
            return friendRequest?.Status;
        }
    }