using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESOF.WebApp.WebAPI.Services
{
    public class ParticipantService
    {
        private readonly ApplicationDbContext _context;

        public ParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ResponseParticipantDto> GetAllParticipants()
        {
            try
            {
                var participants = _context.Participants
                    .Include(p => p.User)
                    .Include(p => p.BlindEvent)
                    .ToList();

                return participants.Select(p => new ResponseParticipantDto
                {
                    ParticipantId = p.ParticipantId,
                    UserId = p.UserId,
                    BlindEventId = p.BlindEventId,
                    User = new ResponseUserDto
                    {
                        UserId = p.User.UserId,
                        Email = p.User.Email
                    },
                    BlindEvent = new ResponseBlindEventDto
                    {
                        BlindEventId = p.BlindEvent.BlindEventId,
                        EventDate = p.BlindEvent.EventDate,
                        Name = p.BlindEvent.Name,
                        OrganizerId = p.BlindEvent.OrganizerId
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving participants.", ex);
            }
        }

        public ResponseParticipantDto GetParticipantById(Guid id)
        {
            try
            {
                var participant = _context.Participants
                    .Include(p => p.User)
                    .Include(p => p.BlindEvent)
                    .FirstOrDefault(p => p.ParticipantId == id);

                if (participant == null)
                {
                    throw new ArgumentException("Participant not found.");
                }

                return new ResponseParticipantDto
                {
                    ParticipantId = participant.ParticipantId,
                    UserId = participant.UserId,
                    BlindEventId = participant.BlindEventId,
                    User = new ResponseUserDto
                    {
                        UserId = participant.User.UserId,
                        Email = participant.User.Email
                    },
                    BlindEvent = new ResponseBlindEventDto
                    {
                        BlindEventId = participant.BlindEvent.BlindEventId,
                        EventDate = participant.BlindEvent.EventDate,
                        Name = participant.BlindEvent.Name,
                        OrganizerId = participant.BlindEvent.OrganizerId
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving participant with ID {id}.", ex);
            }
        }

        public ResponseParticipantDto CreateParticipant(CreateParticipantDto createParticipantDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = _context.Users.Find(createParticipantDto.UserId);
                    if (user == null)
                    {
                        throw new ArgumentException("User not found.");
                    }

                    var blindEvent = _context.BlindEvents.Find(createParticipantDto.BlindEventId);
                    if (blindEvent == null)
                    {
                        throw new ArgumentException("Blind event not found.");
                    }

                    var participant = new Participant
                    {
                        UserId = createParticipantDto.UserId,
                        BlindEventId = createParticipantDto.BlindEventId
                    };

                    _context.Participants.Add(participant);
                    _context.SaveChanges();

                    transaction.Commit();

                    return new ResponseParticipantDto
                    {
                        ParticipantId = participant.ParticipantId,
                        UserId = participant.UserId,
                        BlindEventId = participant.BlindEventId,
                        User = new ResponseUserDto
                        {
                            UserId = user.UserId,
                            Email = user.Email
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
                    throw new Exception("An error occurred while creating the participant. Please try again later.", ex);
                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteParticipant(Guid id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var participant = _context.Participants
                        .Include(p => p.Evaluations)
                        .Include(p => p.ParticipantWines)
                        .FirstOrDefault(p => p.ParticipantId == id);

                    if (participant == null)
                    {
                        throw new ArgumentException("Participant not found.");
                    }

                    _context.Evaluations.RemoveRange(participant.Evaluations);
                    _context.ParticipantWines.RemoveRange(participant.ParticipantWines);
                    _context.Participants.Remove(participant);

                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Concurrency conflict occurred while deleting the participant.", ex);
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while deleting the participant.", ex);
                }
            }
        }
        
        public List<ResponseUserDto> GetAvailableUsers()
        {
            try
            {
                var users = _context.Users
                    .Where(u => !_context.Participants.Any(p => p.UserId == u.UserId))
                    .Select(u => new ResponseUserDto
                    {
                        UserId = u.UserId,
                        Email = u.Email
                    }).ToList();

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving users.", ex);
            }
        }


    }
}
    