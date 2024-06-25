using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class FriendshipService
{
    private readonly ApplicationDbContext _context;

    public FriendshipService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<FriendDto>> GetFriendsForUserAsync(Guid userId)
    {
        var users = await _context.Friendships
            .Where(f => f.UserId1 == userId || f.UserId2 == userId)
            .Select(f => f.UserId1 == userId ? f.User2 : f.User1)
            .ToListAsync();

        var friends = users.Select(u => new FriendDto
        {
            UserId = u.UserId,
            UserName = u.UserName
        }).ToList();

        return friends;
    }
    
    
        
    public async Task RemoveFriendAsync(Guid userId1, Guid userId2)
    {
        var friendship = await _context.Friendships
            .FirstOrDefaultAsync(f => (f.UserId1 == userId1 && f.UserId2 == userId2) || (f.UserId1 == userId2 && f.UserId2 == userId1));

        if (friendship == null)
            throw new FriendshipNotFoundException("Friendship not found");

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                // Remove the friendship
                _context.Friendships.Remove(friendship);

                // Decrement friends count for both users
                var requester = await _context.Users.FindAsync(userId1);
                var receiver = await _context.Users.FindAsync(userId2);

                if (requester != null)
                {
                    requester.FriendsCount--;
                }

                if (receiver != null)
                {
                    receiver.FriendsCount--;
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
    
    //get received friend requests with status pending
    public async Task<List<FriendRequestDto>> GetReceivedFriendRequestsAsync(Guid userId)
    {
        var friendRequests = await _context.FriendRequests
            .Where(fr => fr.ReceiverId == userId && fr.Status == FriendRequestState.PENDING)
            .Include(fr => fr.Requester)
            .ToListAsync();

        var friendRequestsDtos = friendRequests.Select(fr => new FriendRequestDto
        {
            RequestId = fr.RequestId,
            RequesterId = fr.Requester.UserId,
            RequesterName = fr.Requester.UserName
        }).ToList();

        return friendRequestsDtos;
    }
    
    //get sent friend requests with status pending
    public async Task<List<FriendRequestDto>> GetSentFriendRequestsAsync(Guid userId)
    {
        var friendRequests = await _context.FriendRequests
            .Where(fr => fr.RequesterId == userId && fr.Status == FriendRequestState.PENDING)
            .Include(fr => fr.Receiver)
            .ToListAsync();

        var friendRequestsDtos = friendRequests.Select(fr => new FriendRequestDto
        {
            RequestId = fr.RequestId,
            ReceiverId = fr.Receiver.UserId,
            ReceiverName = fr.Receiver.UserName
        }).ToList();

        return friendRequestsDtos;
    }
    
    //accept friend request
    public async Task AcceptFriendRequestAsync(Guid requestId)
    {
        var friendRequest = await _context.FriendRequests.FindAsync(requestId);
        if (friendRequest == null)
            throw new ApplicationException("Friend request not found");

        // Adicionar a amizade
        var friendship = new Friendship
        {
            UserId1 = friendRequest.RequesterId,
            UserId2 = friendRequest.ReceiverId
        };
        _context.Friendships.Add(friendship);

        // Remover o pedido de amizade
        _context.FriendRequests.Remove(friendRequest);

        await _context.SaveChangesAsync();
    }
    
    //cancel friend request
    public async Task CancelFriendRequestAsync(Guid requestId)
    {
        var friendRequest = await _context.FriendRequests.FindAsync(requestId);
        if (friendRequest == null)
            throw new ApplicationException("Friend request not found");

        _context.FriendRequests.Remove(friendRequest);

        await _context.SaveChangesAsync();
    }
    
    //send friend request
    public async Task SendFriendRequestAsync(Guid requesterId, Guid receiverId)
    {
        var friendRequest = new FriendRequest
        {
            RequesterId = requesterId,
            ReceiverId = receiverId,
            Status = FriendRequestState.PENDING,
            CreatedAt = DateTime.Now
        };

        _context.FriendRequests.Add(friendRequest);

        await _context.SaveChangesAsync();
    }

}

public class FriendshipNotFoundException : Exception
{
    public FriendshipNotFoundException(string message) : base(message)
    {
    }
}