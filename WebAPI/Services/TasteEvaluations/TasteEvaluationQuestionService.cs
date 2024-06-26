using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class TasteEvaluationQuestionService(ApplicationDbContext context)
{
    /**
     *
     * Get all taste evaluation questions.
     *
     * @return The taste evaluation questions.
     * 
     */
    public List<ResponseTasteEvaluationQuestionDto> GetAll()
    {
        try
        {
            return context.TasteEvaluationQuestions.Select(tasteEvaluationQuestion => new ResponseTasteEvaluationQuestionDto
            {
                TasteEvaluationQuestionId = tasteEvaluationQuestion.TasteEvaluationQuestionId,
                TasteEvaluationId = tasteEvaluationQuestion.TasteEvaluationId,
                TasteQuestionId = tasteEvaluationQuestion.TasteQuestionId,
                Value = tasteEvaluationQuestion.Value
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error: An error occurred while retrieving the taste evaluation questions: " + ex.Message + "(" + ex.InnerException + ")");
        }
    }

    /**
     *
     * Get a taste evaluation question by the given id.
     *
     * @param id The id of the taste evaluation question to get.
     *
     * @return The taste evaluation question.
     * 
     */
    public ResponseTasteEvaluationQuestionDto Get(Guid id)
    {
        var tasteEvaluationQuestion = context.TasteEvaluationQuestions.Find(id);
        if (tasteEvaluationQuestion == null)
        {
            throw new ArgumentException("Error: That taste evaluation question does not exist!");
        }

        return new ResponseTasteEvaluationQuestionDto
        {
            TasteEvaluationQuestionId = tasteEvaluationQuestion.TasteEvaluationQuestionId,
            TasteEvaluationId = tasteEvaluationQuestion.TasteEvaluationId,
            TasteQuestionId = tasteEvaluationQuestion.TasteQuestionId,
            Value = tasteEvaluationQuestion.Value
        };
    }

    /**
     *
     * Create a taste evaluation question based on the given data.
     *
     * @param createTasteEvaluationQuestionDto The data to create the taste evaluation question with.
     *
     * @return The created taste evaluation question.
     * 
     */
    public ResponseTasteEvaluationQuestionDto Create(CreateTasteEvaluationQuestionDto createTasteEvaluationQuestionDto)
    {
        try
        {
            var tasteEvaluationQuestion = new TasteEvaluationQuestion
            {
                TasteEvaluationId = createTasteEvaluationQuestionDto.TasteEvaluationId,
                TasteQuestionId = createTasteEvaluationQuestionDto.TasteQuestionId,
                Value = createTasteEvaluationQuestionDto.Value
            };
            
            if (context.TasteEvaluationQuestions.Any(teq => teq.TasteEvaluationId == tasteEvaluationQuestion.TasteEvaluationId && teq.TasteQuestionId == tasteEvaluationQuestion.TasteQuestionId))
            {
                throw new ArgumentException("Error: That taste evaluation question already exists!");
            }
            
            if (!context.TasteEvaluations.Any(te => te.TasteEvaluationId == tasteEvaluationQuestion.TasteEvaluationId))
            {
                throw new ArgumentException("Error: That taste evaluation does not exist!");
            }
            
            if (!context.TasteQuestions.Any(tq => tq.TasteQuestionId == tasteEvaluationQuestion.TasteQuestionId))
            {
                throw new ArgumentException("Error: That taste question does not exist!");
            }

            context.TasteEvaluationQuestions.Add(tasteEvaluationQuestion);
            context.SaveChanges();

            return new ResponseTasteEvaluationQuestionDto
            {
                TasteEvaluationQuestionId = tasteEvaluationQuestion.TasteEvaluationQuestionId,
                TasteEvaluationId = tasteEvaluationQuestion.TasteEvaluationId,
                TasteQuestionId = tasteEvaluationQuestion.TasteQuestionId,
                Value = tasteEvaluationQuestion.Value
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error: An error occurred while creating the taste evaluation question: " + ex.Message + "(" + ex.InnerException + ")");
        }
    }

    /**
     * 
     * Update a taste evaluation question based on the given id.
     *
     * @param id The id of the taste evaluation question to update.
     * @param updateTasteEvaluationQuestionDto The data to update the taste evaluation question with.
     *
     * @return The updated taste evaluation question.
     * 
     */
    public ResponseTasteEvaluationQuestionDto Update(Guid id, UpdateTasteEvaluationQuestionDto updateTasteEvaluationDto)
    {
        var tasteEvaluationQuestion = context.TasteEvaluationQuestions.Find(id);

        if (tasteEvaluationQuestion == null)
        {
            throw new ArgumentException("Error: That taste evaluation question does not exist!");
        }

        if (context.TasteEvaluationQuestions.Any(teq => teq.TasteEvaluationId == updateTasteEvaluationDto.TasteEvaluationId && teq.TasteQuestionId == updateTasteEvaluationDto.TasteQuestionId))
        {
            throw new ArgumentException("Error: That taste evaluation question already exists!");
        }
        
        if (!context.TasteEvaluations.Any(te => te.TasteEvaluationId == updateTasteEvaluationDto.TasteEvaluationId))
        {
            throw new ArgumentException("Error: That taste evaluation does not exist!");
        }
        
        if (!context.TasteQuestions.Any(tq => tq.TasteQuestionId == updateTasteEvaluationDto.TasteQuestionId))
        {
            throw new ArgumentException("Error: That taste question does not exist!");
        }
        
        tasteEvaluationQuestion.TasteEvaluationId = updateTasteEvaluationDto.TasteEvaluationId;
        tasteEvaluationQuestion.TasteQuestionId = updateTasteEvaluationDto.TasteQuestionId;
        tasteEvaluationQuestion.Value = updateTasteEvaluationDto.Value;

        context.SaveChanges();

        return new ResponseTasteEvaluationQuestionDto
        {
            TasteEvaluationQuestionId = tasteEvaluationQuestion.TasteEvaluationQuestionId,
            TasteEvaluationId = tasteEvaluationQuestion.TasteEvaluationId,
            TasteQuestionId = tasteEvaluationQuestion.TasteQuestionId,
            Value = tasteEvaluationQuestion.Value
        };
    }

    /**
     *
     * Delete a taste evaluation question based on the given id.
     *
     * @param id The id of the taste evaluation question to delete.
     * 
     */
    public void Delete(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var tasteEvaluationQuestion = context.TasteEvaluationQuestions.Find(id);

                if (tasteEvaluationQuestion == null)
                {
                    throw new ArgumentException("Error: That taste evaluation does not exist!");
                }

                context.TasteEvaluationQuestions.Remove(tasteEvaluationQuestion);
                context.SaveChanges();
                
                // if everything is correct, just commit the transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                
                throw new Exception("Error: An error occurred while trying to delete the taste evaluation question: " + ex.Message + "(" + ex.InnerException + ")");
            }
        }
    }
}