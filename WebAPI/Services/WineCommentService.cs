using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.DtoClasses;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class WineCommentService(ApplicationDbContext context)
{
    public CreateWineCommentDto CreateWineComment(CreateWineCommentDto createWineCommentDto)
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

            context.WineComments.Add(wineComment);
            context.SaveChanges();
            
            return createWineCommentDto;
            
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error when creating a comment!", ex);
        }
    }
}