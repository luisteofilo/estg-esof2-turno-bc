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
            var requesterExists = await _context.Users.AnyAsync(u => u.UserId == requesterId);
            var receiverExists = await _context.Users.AnyAsync(u => u.UserId == receiverId);

            if (!requesterExists)
            {
                throw new InvalidOperationException("Requester does not exist.");
            }

            if (!receiverExists)
            {
                throw new InvalidOperationException("Receiver does not exist.");
            }

            // Check if a pending friend request already exists between the users in either direction
            var existingRequest = await _context.FriendRequests
                .FirstOrDefaultAsync(fr =>
                    (fr.RequesterId == requesterId && fr.ReceiverId == receiverId && fr.Status == FriendRequestState.PENDING) ||
                    (fr.RequesterId == receiverId && fr.ReceiverId == requesterId && fr.Status == FriendRequestState.PENDING));

            if (existingRequest != null)
            {
                throw new InvalidOperationException("A pending friend request already exists between these users.");
            }

            // Check if they are already friends
            var existingFriendship = await _context.Friendships
                .FirstOrDefaultAsync(f =>
                    (f.UserId1 == requesterId && f.UserId2 == receiverId) ||
                    (f.UserId1 == receiverId && f.UserId2 == requesterId));

            if (existingFriendship != null)
            {
                throw new InvalidOperationException("The users are already friends.");
            }

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
                throw new FriendRequestNotFoundException("Friend request not found");
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
            
            var requester = await _context.Users.FindAsync(friendRequest.RequesterId);
            var receiver = await _context.Users.FindAsync(friendRequest.ReceiverId);

            if (requester != null)
            {
                requester.FriendsCount++;
            }

            if (receiver != null)
            {
                receiver.FriendsCount++;
            }

            await _context.SaveChangesAsync();
        }

        public async Task RejectFriendRequestAsync(Guid requestId)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(requestId);
            if (friendRequest == null)
            {
                throw new FriendRequestNotFoundException("Friend request not found");
            }

            friendRequest.Status = FriendRequestState.REFUSED;
            await _context.SaveChangesAsync();
        }

        public async Task<List<FriendRequest>> GetReceivedFriendRequestsForUserAsync(Guid userId)
        {
            return await _context.FriendRequests
                .Include(fr => fr.Requester)
                .Include(fr => fr.Receiver)
                .Where(fr => fr.ReceiverId == userId && fr.Status == FriendRequestState.PENDING)
                .ToListAsync();
        }

        public async Task<List<FriendRequest>> GetSentPendingFriendRequestsAsync(Guid userId)
        {
            return await _context.FriendRequests
                .Include(fr => fr.Requester)
                .Include(fr => fr.Receiver)
                .Where(fr => fr.RequesterId == userId && fr.Status == FriendRequestState.PENDING)
                .ToListAsync();
        }
        
        public async Task RemovePendingFriendRequestAsync(Guid requestId)
        {
            var friendRequest = await _context.FriendRequests
                .FirstOrDefaultAsync(fr =>
                    fr.RequestId == requestId &&
                    
                    fr.Status == FriendRequestState.PENDING);

            if (friendRequest == null)
            {
                throw new FriendRequestNotFoundException("Pending friend request not found");
            }

            _context.FriendRequests.Remove(friendRequest);
            await _context.SaveChangesAsync();
        }
    }

    public class FriendRequestNotFoundException : Exception
    {
        public FriendRequestNotFoundException(string message) : base(message)
        {
        }
    }