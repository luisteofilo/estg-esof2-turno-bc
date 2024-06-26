    using ESOF.WebApp.DBLayer.Context;
    using ESOF.WebApp.DBLayer.DtoClasses;
    using ESOF.WebApp.DBLayer.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    namespace ESOF.WebApp.WebAPI.Services;
    
    public class WineCommentService
    {
        private readonly ApplicationDbContext _context;
        
        public WineCommentService(ApplicationDbContext context)
        {
            _context = context;
        }


        
        public async Task<IEnumerable<ResponseWineCommentDto>> GetWineCommentsByWine(Guid id)
        {
            try
            {
                var wineComments = await _context.WineComments
                    .Where(w => w.WineId == id)
                    .ToListAsync();

                /*if (wineComments.Count == 0)
                {
                    throw new ArgumentException("This wine has no comments.");
                }*/
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
        public async Task<ResponseWineCommentDto> CreateWineComment(CreateWineCommentDto createWineCommentDto)
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
                    WineId = wineComment.WineId,
                    UserId = wineComment.UserId
                };
                
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error when creating a comment.", ex);
            }
        }
        
        public ResponseWineCommentDto UpdateWineComment(Guid id, UpdateWineCommentDto updateWineCommentDto)
        {
                try
                {
                    var wineComment = _context.WineComments
                        .FirstOrDefault(w => w.WineCommentId == id);

                    if (wineComment == null)
                    {
                        throw new ArgumentException("Wine comment not found.");
                    }

                    wineComment.Comment = updateWineCommentDto.Comment ?? wineComment.Comment;
                    wineComment.Evaluation = updateWineCommentDto.Evaluation ?? wineComment.Evaluation;
                    wineComment.UpdatedAt = DateTimeOffset.UtcNow;

                    _context.SaveChanges();

                    return new ResponseWineCommentDto
                    {
                        WineCommentId = wineComment.WineCommentId,
                        Comment = wineComment.Comment,
                        Evaluation = wineComment.Evaluation,
                        CreatedAt = wineComment.CreatedAt,
                        UpdatedAt = wineComment.UpdatedAt,
                        WineId = wineComment.WineId,
                        UserId = wineComment.UserId
                    };
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("Error when updating comment.", ex);
                }
        }
        
        public void DeleteWineComment(Guid id)
        {
            try
            {
                var wineComment = _context.WineComments
                    .FirstOrDefault(w => w.WineCommentId == id);

                if (wineComment == null)
                {
                    throw new ArgumentException("Wine Comment not found.");
                }
                
                _context.WineComments.Remove(wineComment);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Concurrency conflict occurred while deleting the comment", ex); 
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the comment.", ex); 
            }
        }
        
    }