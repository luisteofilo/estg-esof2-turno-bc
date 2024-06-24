using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESOF.WebApp.WebAPI.Services
{
    public class ParticipantWineService
    {
        private readonly ApplicationDbContext _context;

        public ParticipantWineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ResponseParticipantWineDto> GetAllParticipantWines()
        {
            try
            {
                var participantWines = _context.ParticipantWines
                    .Include(pw => pw.Participant)
                    .Include(pw => pw.Wine)
                    .Include(pw => pw.BlindEvent)
                    .ToList();

                return participantWines.Select(pw => new ResponseParticipantWineDto
                {
                    ParticipantWineId = pw.ParticipantWineId,
                    ParticipantId = pw.ParticipantId,
                    WineId = pw.WineId,
                    BlindEventId = pw.BlindEventId,
                    Participant = new ResponseParticipantDto
                    {
                        ParticipantId = pw.Participant.ParticipantId,
                        UserId = pw.Participant.UserId,
                        BlindEventId = pw.Participant.BlindEventId
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
                    },
                    BlindEvent = new ResponseBlindEventDto
                    {
                        BlindEventId = pw.BlindEvent.BlindEventId,
                        EventDate = pw.BlindEvent.EventDate,
                        Name = pw.BlindEvent.Name,
                        OrganizerId = pw.BlindEvent.OrganizerId
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving participant wines.", ex);
            }
        }

        public ResponseParticipantWineDto GetParticipantWineById(Guid id)
        {
            try
            {
                var participantWine = _context.ParticipantWines
                    .Include(pw => pw.Participant)
                    .Include(pw => pw.Wine)
                    .Include(pw => pw.BlindEvent)
                    .FirstOrDefault(pw => pw.ParticipantWineId == id);

                if (participantWine == null)
                {
                    throw new ArgumentException("ParticipantWine not found.");
                }

                return new ResponseParticipantWineDto
                {
                    ParticipantWineId = participantWine.ParticipantWineId,
                    ParticipantId = participantWine.ParticipantId,
                    WineId = participantWine.WineId,
                    BlindEventId = participantWine.BlindEventId,
                    Participant = new ResponseParticipantDto
                    {
                        ParticipantId = participantWine.Participant.ParticipantId,
                        UserId = participantWine.Participant.UserId,
                        BlindEventId = participantWine.Participant.BlindEventId
                    },
                    Wine = new ResponseWineDto
                    {
                        WineId = participantWine.Wine.WineId,
                        Label = participantWine.Wine.label,
                        Year = participantWine.Wine.Year,
                        Category = participantWine.Wine.category,
                        LabelDesignation = participantWine.Wine.LabelDesignation,
                        Alcohol = participantWine.Wine.Alcohol,
                        MinimumPrice = participantWine.Wine.MinimumPrice,
                        MaximumPrice = participantWine.Wine.MaximumPrice,
                        CreatedAt = participantWine.Wine.CreatedAt,
                        UpdatedAt = participantWine.Wine.UpdatedAt,
                        BrandId = participantWine.Wine.BrandId,
                        RegionId = participantWine.Wine.RegionId
                    },
                    BlindEvent = new ResponseBlindEventDto
                    {
                        BlindEventId = participantWine.BlindEvent.BlindEventId,
                        EventDate = participantWine.BlindEvent.EventDate,
                        Name = participantWine.BlindEvent.Name,
                        OrganizerId = participantWine.BlindEvent.OrganizerId
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving participant wine with ID {id}.", ex);
            }
        }

        public ResponseParticipantWineDto CreateParticipantWine(CreateParticipantWineDto createParticipantWineDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var participant = _context.Participants.Find(createParticipantWineDto.ParticipantId);
                    if (participant == null)
                    {
                        throw new ArgumentException("Participant not found.");
                    }

                    var wine = _context.Wines.Find(createParticipantWineDto.WineId);
                    if (wine == null)
                    {
                        throw new ArgumentException("Wine not found.");
                    }

                    var blindEvent = _context.BlindEvents.Find(createParticipantWineDto.BlindEventId);
                    if (blindEvent == null)
                    {
                        throw new ArgumentException("Blind event not found.");
                    }

                    var participantWine = new ParticipantWine
                    {
                        ParticipantId = createParticipantWineDto.ParticipantId,
                        WineId = createParticipantWineDto.WineId,
                        BlindEventId = createParticipantWineDto.BlindEventId
                    };

                    _context.ParticipantWines.Add(participantWine);
                    _context.SaveChanges();

                    transaction.Commit();

                    return new ResponseParticipantWineDto
                    {
                        ParticipantWineId = participantWine.ParticipantWineId,
                        ParticipantId = participantWine.ParticipantId,
                        WineId = participantWine.WineId,
                        BlindEventId = participantWine.BlindEventId,
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
                    throw new Exception("An error occurred while creating the participant wine. Please try again later.", ex);
                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteParticipantWine(Guid id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var participantWine = _context.ParticipantWines.FirstOrDefault(pw => pw.ParticipantWineId == id);

                    if (participantWine == null)
                    {
                        throw new ArgumentException("ParticipantWine not found.");
                    }

                    _context.ParticipantWines.Remove(participantWine);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Concurrency conflict occurred while deleting the participant wine.", ex);
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while deleting the participant wine.", ex);
                }
            }
        }
    }
}
