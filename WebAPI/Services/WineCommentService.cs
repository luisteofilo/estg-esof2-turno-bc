using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.DtoClasses;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class WineCommentService
{
    private readonly ApplicationDbContext _context;
    
    public WineCommentService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<WineComment> CreateWineComment(CreateWineCommentDto createWineCommentDto)
    {
        try
        {
            var wineComment = new WineComment
            {
                Comment = createWineCommentDto.Comment,
                Evaluation = createWineCommentDto.Evaluation,
                WineId = createWineCommentDto.WineId,
                UserId = createWineCommentDto.UserId
            };

            _context.WineComments.Add(wineComment);
            await _context.SaveChangesAsync();
            
            //return createWineCommentDto;
            return wineComment;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error when creating a comment!", ex);
        }
    }
    public async Task<List<WineComment>> GetWineComments(Guid wineId)//Esta função devolve todos os comentários de um vinho asynchronamente
    {
        return await _context.WineComments.Where(c => c.WineId == wineId).ToListAsync();
    }
    
}