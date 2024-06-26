using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class TasteEvaluationService(ApplicationDbContext context)
{
    /**
     *
     * Get all taste evaluations.
     *
     * @return The taste evaluations.
     * 
     */
    public List<ResponseTasteEvaluationDto> GetAll()
    {
        try
        {
            return context.TasteEvaluations.Select(tasteEvaluation => new ResponseTasteEvaluationDto
            {
                TasteEvaluationId = tasteEvaluation.TasteEvaluationId,
                UserId = tasteEvaluation.UserId,
                WineId = tasteEvaluation.WineId,
                EventId = tasteEvaluation.EventId,
                WineScore = tasteEvaluation.WineScore
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error: An error occurred while retrieving the TasteEvaluation: " + ex.Message + "(" + ex.InnerException + ")");
        }
    }

    /**
     *
     * Get a taste evaluation by the given id.
     *
     * @param id The id of the taste evaluation to get.
     *
     * @return The taste evaluation.
     * 
     */
    public ResponseTasteEvaluationDto Get(Guid id)
    {
        var tasteEvaluation = context.TasteEvaluations.Find(id);
        if (tasteEvaluation == null)
        {
            throw new ArgumentException("Error: That taste evaluation does not exist!");
        }

        return new ResponseTasteEvaluationDto
        {
            TasteEvaluationId = tasteEvaluation.TasteEvaluationId,
            UserId = tasteEvaluation.UserId,
            WineId = tasteEvaluation.WineId,
            EventId = tasteEvaluation.EventId,
            WineScore = tasteEvaluation.WineScore
        };
    }

    /**
     *
     * Create a taste evaluation based on the given data.
     *
     * @param createTasteEvaluationDto The data to create the taste evaluation with.
     *
     * @return The created taste evaluation.
     * 
     */
    public ResponseTasteEvaluationDto Create(CreateTasteEvaluationDto createTasteEvaluationDto)
    {
        try
        {
            TasteEvaluation tasteEvaluation;
                
            if (createTasteEvaluationDto.TasteEvaluationId != null)
            {
                tasteEvaluation = new TasteEvaluation
                {
                    TasteEvaluationId = createTasteEvaluationDto.TasteEvaluationId,
                    UserId = createTasteEvaluationDto.UserId,
                    WineId = createTasteEvaluationDto.WineId,
                    EventId = createTasteEvaluationDto.EventId,
                    WineScore = createTasteEvaluationDto.WineScore
                };
            }
            else
            {
                tasteEvaluation = new TasteEvaluation
                {
                    UserId = createTasteEvaluationDto.UserId,
                    WineId = createTasteEvaluationDto.WineId,
                    EventId = createTasteEvaluationDto.EventId,
                    WineScore = createTasteEvaluationDto.WineScore
                };
            }

            context.TasteEvaluations.Add(tasteEvaluation);
            context.SaveChanges();

            return new ResponseTasteEvaluationDto
            {
                TasteEvaluationId = tasteEvaluation.TasteEvaluationId,
                UserId = tasteEvaluation.UserId,
                WineId = tasteEvaluation.WineId,
                EventId = tasteEvaluation.EventId,
                WineScore = tasteEvaluation.WineScore
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error: An error occurred while creating the TasteEvaluation: " + ex.Message + "(" + ex.InnerException + ")");
        }
    }

    /**
     * 
     * Update a taste evaluation based on the given id.
     *
     * @param id The id of the taste evaluation to update.
     * @param updateTasteEvaluationDto The data to update the taste evaluation with.
     *
     * @return The updated taste evaluation.
     * 
     */
    public ResponseTasteEvaluationDto Update(Guid id, UpdateTasteEvaluationDto updateTasteEvaluationDto)
    {
        var tasteEvaluation = context.TasteEvaluations.Find(id);

        if (tasteEvaluation == null)
        {
            throw new ArgumentException("Error: That taste evaluation does not exist!");
        }

        tasteEvaluation.UserId = updateTasteEvaluationDto.UserId;
        tasteEvaluation.WineId = updateTasteEvaluationDto.WineId;
        tasteEvaluation.EventId = updateTasteEvaluationDto.EventId;
        tasteEvaluation.WineScore = updateTasteEvaluationDto.WineScore;

        context.SaveChanges();

        return new ResponseTasteEvaluationDto
        {
            TasteEvaluationId = tasteEvaluation.TasteEvaluationId,
            UserId = tasteEvaluation.UserId,
            WineId = tasteEvaluation.WineId,
            EventId = tasteEvaluation.EventId,
            WineScore = tasteEvaluation.WineScore
        };
    }

    /**
     *
     * Delete a taste evaluation based on the given id.
     *
     * @param id The id of the taste evaluation to delete.
     * 
     */
    public void Delete(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var tasteEvaluation = context.TasteEvaluations.Find(id);

                if (tasteEvaluation == null)
                {
                    throw new ArgumentException("Error: That taste evaluation does not exist!");
                }

                context.TasteEvaluations.Remove(tasteEvaluation);
                context.SaveChanges();
                
                // if everything is correct, just commit the transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                
                throw new Exception("Error: An error occurred while trying to delete the TasteEvaluation: " + ex.Message + "(" + ex.InnerException + ")");
            }
        }
    }
}