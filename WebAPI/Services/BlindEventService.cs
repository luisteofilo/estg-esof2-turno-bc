using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESOF.WebApp.WebAPI.Services
{
    public class BlindEventService
    {
        
        public List<ResponseBlindEventDto> GetAllBlindEvents()
        {
            try
            {
                var db = new ApplicationDbContext();
                var blindEvents = db.BlindEvents
                    .Include(be => be.Organizer)
                    .Include(be => be.Participants)
                    .Include(be => be.Evaluations)
                    .Include(be => be.ParticipantWines)
                    .ToList();

                return blindEvents.Select(be => new ResponseBlindEventDto
                {
                    BlindEventId = be.BlindEventId,
                    EventDate = be.EventDate,
                    Name = be.Name,
                    OrganizerId = be.OrganizerId,
                    ParticipantIds = be.Participants.Select(p => p.ParticipantId),
                    EvalutionIds = be.Evaluations.Select(e => e.EvaluationId),
                    ParticipantWineIds = be.ParticipantWines.Select(pw => pw.ParticipantWineId),
                    Organizer = new ResponseUserDto
                    {
                        UserId = be.Organizer.UserId,
                        Email = be.Organizer.Email
                    },
                    Participants = be.Participants.Select(p => new ResponseParticipantDto
                    {
                        ParticipantId = p.ParticipantId,
                        UserId = p.UserId,
                        BlindEventId = p.BlindEventId
                    }).ToList(),
                    Evaluations = be.Evaluations.Select(e => new ResponseEvaluationDto
                    {
                        EvaluationId = e.EvaluationId,
                        ParticipantId = e.ParticipantId,
                        WineId = e.WineId,
                        BlindEventId = e.BlindEventId,
                        Grade = e.Grade
                    }).ToList(),
                    ParticipantWines = be.ParticipantWines.Select(pw => new ResponseParticipantWineDto
                    {
                        ParticipantWineId = pw.ParticipantWineId,
                        ParticipantId = pw.ParticipantId,
                        WineId = pw.WineId,
                        BlindEventId = pw.BlindEventId
                    }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving blind events.", ex);
            }
        }

        public ResponseBlindEventDto GetBlindEventById(Guid id)
{
    try
    {
        var db = new ApplicationDbContext();
        var blindEvent = db.BlindEvents
            .Include(be => be.Organizer)
            .Include(be => be.Participants)
                .ThenInclude(p => p.User)
            .Include(be => be.Evaluations)
                .ThenInclude(e => e.Participant)
                    .ThenInclude(p => p.User)
            .Include(be => be.Evaluations)
                .ThenInclude(e => e.Wine)
            .Include(be => be.ParticipantWines)
                .ThenInclude(pw => pw.Wine)
            .Include(be => be.ParticipantWines)
                .ThenInclude(pw => pw.Participant)
                    .ThenInclude(p => p.User)
            .FirstOrDefault(be => be.BlindEventId == id);

        if (blindEvent == null)
        {
            throw new ArgumentException("Blind event not found.");
        }

        return new ResponseBlindEventDto
        {
            BlindEventId = blindEvent.BlindEventId,
            EventDate = blindEvent.EventDate,
            Name = blindEvent.Name,
            OrganizerId = blindEvent.OrganizerId,
            ParticipantIds = blindEvent.Participants.Select(p => p.ParticipantId),
            EvalutionIds = blindEvent.Evaluations.Select(e => e.EvaluationId),
            ParticipantWineIds = blindEvent.ParticipantWines.Select(pw => pw.ParticipantWineId),
            Organizer = new ResponseUserDto
            {
                UserId = blindEvent.Organizer.UserId,
                Email = blindEvent.Organizer.Email
            },
            Participants = blindEvent.Participants.Select(p => new ResponseParticipantDto
            {
                ParticipantId = p.ParticipantId,
                UserId = p.UserId,
                BlindEventId = p.BlindEventId,
                User = new ResponseUserDto
                {
                    UserId = p.User.UserId,
                    Email = p.User.Email
                }
            }).ToList(),
            Evaluations = blindEvent.Evaluations.Select(e => new ResponseEvaluationDto
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
                    BlindEventId = e.Participant.BlindEventId,
                    User = new ResponseUserDto
                    {
                        UserId = e.Participant.User.UserId,
                        Email = e.Participant.User.Email
                    }
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
                }
            }).ToList(),
            ParticipantWines = blindEvent.ParticipantWines.Select(pw => new ResponseParticipantWineDto
            {
                ParticipantWineId = pw.ParticipantWineId,
                ParticipantId = pw.ParticipantId,
                WineId = pw.WineId,
                BlindEventId = pw.BlindEventId,
                Participant = new ResponseParticipantDto
                {
                    ParticipantId = pw.Participant.ParticipantId,
                    UserId = pw.Participant.UserId,
                    BlindEventId = pw.Participant.BlindEventId,
                    User = new ResponseUserDto
                    {
                        UserId = pw.Participant.User.UserId,
                        Email = pw.Participant.User.Email
                    }
                },
                Wine = new ResponseWineDto
                {
                    WineId = pw.Wine.WineId,
                    Label = pw.Wine.label,
                    Year = pw.Wine.Year,
                    Category = pw.Wine.category,
                    LabelDesignation = pw.Wine.LabelDesignation,
                    Alcohol = pw.Wine.Alcohol,
                    MinimumPrice = pw.Wine.MinimumPrice,
                    MaximumPrice = pw.Wine.MaximumPrice,
                    CreatedAt = pw.Wine.CreatedAt,
                    UpdatedAt = pw.Wine.UpdatedAt,
                    BrandId = pw.Wine.BrandId,
                    RegionId = pw.Wine.RegionId
                }
            }).ToList()
        };
    }
    catch (Exception ex)
    {
        throw new Exception($"An error occurred while retrieving blind event with ID {id}.", ex);
    }
}

        public ResponseBlindEventDto CreateBlindEvent(CreateBlindEventDto createBlindEventDto)
        {
            var db = new ApplicationDbContext();
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var organizer = db.Users.Find(createBlindEventDto.OrganizerId);
                    if (organizer == null)
                    {
                        throw new ArgumentException("Organizer not found.");
                    }

                    var blindEvent = new BlindEvent
                    {
                        OrganizerId = createBlindEventDto.OrganizerId,
                        EventDate = createBlindEventDto.EventDate,
                        Name = createBlindEventDto.Name
                    };

                    db.BlindEvents.Add(blindEvent);
                    db.SaveChanges();

                    transaction.Commit();

                    return new ResponseBlindEventDto
                    {
                        BlindEventId = blindEvent.BlindEventId,
                        EventDate = blindEvent.EventDate,
                        Name = blindEvent.Name,
                        OrganizerId = blindEvent.OrganizerId
                    };
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while creating the blind event. Please try again later.", ex);
                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public void DeleteBlindEvent(Guid id)
        {
            var db = new ApplicationDbContext();
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var blindEvent = db.BlindEvents
                        .Include(be => be.Participants)
                        .Include(be => be.Evaluations)
                        .Include(be => be.ParticipantWines)
                        .FirstOrDefault(be => be.BlindEventId == id);

                    if (blindEvent == null)
                    {
                        throw new ArgumentException("Blind event not found.");
                    }

                    db.Participants.RemoveRange(blindEvent.Participants);
                    db.Evaluations.RemoveRange(blindEvent.Evaluations);
                    db.ParticipantWines.RemoveRange(blindEvent.ParticipantWines);
                    db.BlindEvents.Remove(blindEvent);

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Concurrency conflict occurred while deleting the blind event.", ex);
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while deleting the blind event.", ex);
                }
            }
        }
    }
}
