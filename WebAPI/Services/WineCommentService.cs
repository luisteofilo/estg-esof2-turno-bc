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


        
        public IEnumerable<ResponseWineCommentDto> GetWineCommentsByWine(Guid id)
        {
            try
            {
                var wineComments = _context.WineComments
                    .Where(w => w.WineId == id)
                    .ToList();

                if (wineComments.Count == 0)
                {
                    throw new ArgumentException("Wine has no comments!");
                }

                return wineComments.Select(wineComment => new ResponseWineCommentDto
                {
                    WineCommentId = wineComment.WineCommentId,
                    Comment = wineComment.Comment,
                    Evaluation = wineComment.Evaluation,
                    CreatedAt = wineComment.CreatedAt,
                    UpdatedAt = wineComment.UpdatedAt,
                    WineId = wineComment.WineId,
                    UserId = wineComment.UserId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving wine with ID {id}.", ex);
            }
        }
        public ResponseWineCommentDto CreateWineComment(CreateWineCommentDto createWineCommentDto)
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
                _context.SaveChanges();
                
                return new ResponseWineCommentDto
                {
                    WineCommentId = wineComment.WineCommentId,
                    Comment = wineComment.Comment,
                    Evaluation = wineComment.Evaluation,
                    CreatedAt = wineComment.CreatedAt,
                    UpdatedAt = wineComment.UpdatedAt,
                    WineId = wineComment.UserId
                };
                
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error when creating a comment!", ex);
            }
        }
    }