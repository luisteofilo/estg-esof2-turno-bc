using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESOF.WebApp.WebAPI.Services
{
    public class EvaluationService
    {
        private readonly ApplicationDbContext _context;

        public EvaluationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ResponseEvaluationDto> GetAllEvaluations()
        {
            try
            {
                var evaluations = _context.Evaluations
                    .Include(e => e.Participant)
                    .Include(e => e.Wine)
                    .Include(e => e.BlindEvent)
                    .ToList();

                return evaluations.Select(e => new ResponseEvaluationDto
                {
                    EvaluationId = e.EvaluationId,
                    ParticipantId = e.ParticipantId,
                    WineId = e.WineId,
                    BlindEventId = e.BlindEventId,
                    Grade = e.Grade,
                    Participant = new ResponseParticipantDto
                    {
                        ParticipantId = e.Participant.ParticipantId,
                        UserId = e.Participant.UserId,
                        BlindEventId = e.Participant.BlindEventId
                    },
                    Wine = new ResponseWineDto
                    {
                        WineId = e.Wine.WineId,
                        Label = e.Wine.label,
                        Year = e.Wine.Year,
                        Category = e.Wine.category,
                        LabelDesignation = e.Wine.LabelDesignation,
                        Alcohol = e.Wine.Alcohol,
                        MinimumPrice = e.Wine.MinimumPrice,
                        MaximumPrice = e.Wine.MaximumPrice,
                        CreatedAt = e.Wine.CreatedAt,
                        UpdatedAt = e.Wine.UpdatedAt,
                        BrandId = e.Wine.BrandId,
                        RegionId = e.Wine.RegionId
                    },
                    BlindEvent = new ResponseBlindEventDto
                    {
                        BlindEventId = e.BlindEvent.BlindEventId,
                        EventDate = e.BlindEvent.EventDate,
                        Name = e.BlindEvent.Name,
                        OrganizerId = e.BlindEvent.OrganizerId
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving evaluations.", ex);
            }
        }

        public ResponseEvaluationDto GetEvaluationById(Guid id)
        {
            try
            {
                var evaluation = _context.Evaluations
                    .Include(e => e.Participant)
                    .Include(e => e.Wine)
                    .Include(e => e.BlindEvent)
                    .FirstOrDefault(e => e.EvaluationId == id);

                if (evaluation == null)
                {
                    throw new ArgumentException("Evaluation not found.");
                }

                return new ResponseEvaluationDto
                {
                    EvaluationId = evaluation.EvaluationId,
                    ParticipantId = evaluation.ParticipantId,
                    WineId = evaluation.WineId,
                    BlindEventId = evaluation.BlindEventId,
                    Grade = evaluation.Grade,
                    Participant = new ResponseParticipantDto
                    {
                        ParticipantId = evaluation.Participant.ParticipantId,
                        UserId = evaluation.Participant.UserId,
                        BlindEventId = evaluation.Participant.BlindEventId
                    },
                    Wine = new ResponseWineDto
                    {
                        WineId = evaluation.Wine.WineId,
                        Label = evaluation.Wine.label,
                        Year = evaluation.Wine.Year,
                        Category = evaluation.Wine.category,
                        LabelDesignation = evaluation.Wine.LabelDesignation,
                        Alcohol = evaluation.Wine.Alcohol,
                        MinimumPrice = evaluation.Wine.MinimumPrice,
                        MaximumPrice = evaluation.Wine.MaximumPrice,
                        CreatedAt = evaluation.Wine.CreatedAt,
                        UpdatedAt = evaluation.Wine.UpdatedAt,
                        BrandId = evaluation.Wine.BrandId,
                        RegionId = evaluation.Wine.RegionId
                    },
                    BlindEvent = new ResponseBlindEventDto
                    {
                        BlindEventId = evaluation.BlindEvent.BlindEventId,
                        EventDate = evaluation.BlindEvent.EventDate,
                        Name = evaluation.BlindEvent.Name,
                        OrganizerId = evaluation.BlindEvent.OrganizerId
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving evaluation with ID {id}.", ex);
            }
        }

        public ResponseEvaluationDto CreateEvaluation(CreateEvaluationDto createEvaluationDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var participant = _context.Participants.Find(createEvaluationDto.ParticipantId);
                    if (participant == null)
                    {
                        throw new ArgumentException("Participant not found.");
                    }

                    var wine = _context.Wines.Find(createEvaluationDto.WineId);
                    if (wine == null)
                    {
                        throw new ArgumentException("Wine not found.");
                    }

                    var blindEvent = _context.BlindEvents.Find(createEvaluationDto.BlindEventId);
                    if (blindEvent == null)
                    {
                        throw new ArgumentException("Blind event not found.");
                    }

                    // Check if evaluation already exists
                    var existingEvaluation = _context.Evaluations.FirstOrDefault(e =>
                        e.ParticipantId == createEvaluationDto.ParticipantId &&
                        e.WineId == createEvaluationDto.WineId &&
                        e.BlindEventId == createEvaluationDto.BlindEventId);

                    if (existingEvaluation != null)
                    {
                        throw new ArgumentException(
                            "Evaluation already exists for this wine and participant in the event.");
                    }

                    var evaluation = new Evaluation
                    {
                        ParticipantId = createEvaluationDto.ParticipantId,
                        WineId = createEvaluationDto.WineId,
                        BlindEventId = createEvaluationDto.BlindEventId,
                        Grade = createEvaluationDto.Grade
                    };

                    _context.Evaluations.Add(evaluation);
                    _context.SaveChanges();

                    transaction.Commit();

                    return new ResponseEvaluationDto
                    {
                        EvaluationId = evaluation.EvaluationId,
                        ParticipantId = evaluation.ParticipantId,
                        WineId = evaluation.WineId,
                        BlindEventId = evaluation.BlindEventId,
                        Grade = evaluation.Grade,
                        Participant = new ResponseParticipantDto
                        {
                            ParticipantId = participant.ParticipantId,
                            UserId = participant.UserId,
                            BlindEventId = participant.BlindEventId
                        },
                        Wine = new ResponseWineDto
                        {
                            WineId = wine.WineId,
                            Label = wine.label,
                            Year = wine.Year,
                            Category = wine.category,
                            LabelDesignation = wine.LabelDesignation,
                            Alcohol = wine.Alcohol,
                            MinimumPrice = wine.MinimumPrice,
                            MaximumPrice = wine.MaximumPrice,
                            CreatedAt = wine.CreatedAt,
                            UpdatedAt = wine.UpdatedAt,
                            BrandId = wine.BrandId,
                            RegionId = wine.RegionId
                        },
                        BlindEvent = new ResponseBlindEventDto
                        {
                            BlindEventId = blindEvent.BlindEventId,
                            EventDate = blindEvent.EventDate,
                            Name = blindEvent.Name,
                            OrganizerId = blindEvent.OrganizerId
                        }
                    };
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while creating the evaluation. Please try again later.", ex);
                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteEvaluation(Guid id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var evaluation = _context.Evaluations.FirstOrDefault(e => e.EvaluationId == id);

                    if (evaluation == null)
                    {
                        throw new ArgumentException("Evaluation not found.");
                    }

                    _context.Evaluations.Remove(evaluation);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Concurrency conflict occurred while deleting the evaluation.", ex);
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while deleting the evaluation.", ex);
                }
            }
        }
    }
}
