using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class TasteQuestionService(ApplicationDbContext context)
{
    /**
     *
     * Get all taste questions.
     *
     * @return The taste questions.
     * 
     */
    public List<ResponseTasteQuestionDto> GetAll()
    {
        try
        {
            return context.TasteQuestions.Select(tasteQuestion => new ResponseTasteQuestionDto
            {
                TasteQuestionId = tasteQuestion.TasteQuestionId,
                Question = tasteQuestion.Question,
                TasteQuestionTypeId = tasteQuestion.TasteQuestionTypeId
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error: An error occurred while retrieving taste questions: " + ex.Message);
        }
    }

    /**
     *
     * Get a taste question by the given id.
     *
     * @param id The id of the taste question to get.
     *
     * @return The taste question.
     * 
     */
    public ResponseTasteQuestionDto Get(Guid id)
    {
        var tasteQuestion = context.TasteQuestions.Find(id);
        if (tasteQuestion == null)
        {
            throw new ArgumentException("Error: That taste question does not exist!");
        }

        return new ResponseTasteQuestionDto()
        {
            TasteQuestionId = tasteQuestion.TasteQuestionId,
            Question = tasteQuestion.Question,
            TasteQuestionTypeId = tasteQuestion.TasteQuestionTypeId
        };
    }

    /**
     *
     * Create a taste question based on the given data.
     *
     * @param CreateTasteQuestionDto The data to create the taste question with.
     *
     * @return The created taste question.
     * 
     */
    public ResponseTasteQuestionDto Create(CreateTasteQuestionDto createTasteQuestionDto)
    {
        try
        {
            var tasteQuestion = new TasteQuestion
            {
                Question = createTasteQuestionDto.Question,
                TasteQuestionTypeId = createTasteQuestionDto.TasteQuestionTypeId
            };

            context.TasteQuestions.Add(tasteQuestion);
            context.SaveChanges();

            return new ResponseTasteQuestionDto()
            {
                TasteQuestionId = tasteQuestion.TasteQuestionId,
                Question = tasteQuestion.Question,
                TasteQuestionTypeId = tasteQuestion.TasteQuestionTypeId
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error: An error occurred while creating a taste question: " + ex.Message);
        }
    }

    /**
     * 
     * Update a taste question based on the given id.
     *
     * @param id The id of the taste question to update.
     * @param UpdateTasteQuestionDto The data to update the taste question with.
     *
     * @return The updated taste question.
     * 
     */
    public ResponseTasteQuestionDto Update(Guid id, UpdateTasteQuestionDto updateTasteQuestionDto)
    {
        var tasteQuestion = context.TasteQuestions.Find(id);

        if (tasteQuestion == null)
        {
            throw new ArgumentException("Error: That taste question does not exist!");
        }
        
        tasteQuestion.Question = updateTasteQuestionDto.Question;
        tasteQuestion.TasteQuestionTypeId = updateTasteQuestionDto.TasteQuestionTypeId;

        context.SaveChanges();

        return new ResponseTasteQuestionDto()
        {
            TasteQuestionId = tasteQuestion.TasteQuestionId,
            Question = tasteQuestion.Question,
            TasteQuestionTypeId = tasteQuestion.TasteQuestionTypeId
        };
    }

    /**
     *
     * Delete a taste question based on the given id.
     *
     * @param id The id of the taste question to delete.
     * 
     */
    public void Delete(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var tasteQuestion = context.TasteQuestions.Find(id);

                if (tasteQuestion == null)
                {
                    throw new ArgumentException("Error: That taste question does not exist!");
                }
                
                context.TasteQuestions.Remove(tasteQuestion);
                context.SaveChanges();
                
                // if everything is correct, just commit the transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                
                throw new Exception("Error: An error occurred while trying to delete the taste question: " + ex.Message);
            }
        }
    }
}