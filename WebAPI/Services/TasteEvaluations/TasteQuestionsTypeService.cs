using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class TasteQuestionTypeService(ApplicationDbContext context)
{
    /**
     *
     * Get all taste questions type.
     *
     * @return The taste questions type.
     * 
     */
    public List<ResponseTasteQuestionTypeDto> GetAll()
    {
        try
        {
            return context.TasteQuestionTypes.Select(tasteQuestion => new ResponseTasteQuestionTypeDto()
            {
                TasteQuestionTypeId = tasteQuestion.TasteQuestionTypeId,
                Type = tasteQuestion.Type
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error: An error occurred while retrieving taste question types: " + ex.Message + "(" + ex.InnerException + ")");
        }
    }

    /**
     *
     * Get a taste questions type by the given id.
     *
     * @param id The id of the taste questions type to get.
     *
     * @return The taste questions type.
     * 
     */
    public ResponseTasteQuestionTypeDto Get(Guid id)
    {
        var tasteQuestionTypes = context.TasteQuestionTypes.Find(id);
        if (tasteQuestionTypes == null)
        {
            throw new ArgumentException("Error: That taste question type does not exist!");
        }

        return new ResponseTasteQuestionTypeDto()
        {
            TasteQuestionTypeId = tasteQuestionTypes.TasteQuestionTypeId,
            Type = tasteQuestionTypes.Type
        };
    }

    /**
     *
     * Create a taste questions type based on the given data.
     *
     * @param CreateTasteQuestionTypeDto The data to create the taste questions type with.
     *
     * @return The created taste questions type.
     * 
     */
    public ResponseTasteQuestionTypeDto Create(CreateTasteQuestionTypeDto createTasteQuestionTypeDto)
    {
        try
        {
            var tasteQuestionTypes = new TasteQuestionType
            {
                Type = createTasteQuestionTypeDto.Type
            };

            context.TasteQuestionTypes.Add(tasteQuestionTypes);
            context.SaveChanges();

            return new ResponseTasteQuestionTypeDto()
            {
                TasteQuestionTypeId = tasteQuestionTypes.TasteQuestionTypeId,
                Type = tasteQuestionTypes.Type
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error: An error occurred while creating a taste question type: " + ex.Message + "(" + ex.InnerException + ")");
        }
    }

    /**
     * 
     * Update a taste questions type based on the given id.
     *
     * @param id The id of the taste questions type to update.
     * @param UpdateTasteQuestionTypeDto The data to update the taste questions type with.
     *
     * @return The updated taste questions type.
     * 
     */
    public ResponseTasteQuestionTypeDto Update(Guid id, UpdateTasteQuestionTypeDto updateTasteQuestionTypeDto)
    {
        var tasteQuestionTypes = context.TasteQuestionTypes.Find(id);

        if (tasteQuestionTypes == null)
        {
            throw new ArgumentException("Error: That taste questions type does not exist!");
        }
        
        tasteQuestionTypes.Type = updateTasteQuestionTypeDto.Type;

        context.SaveChanges();

        return new ResponseTasteQuestionTypeDto()
        {
            TasteQuestionTypeId = tasteQuestionTypes.TasteQuestionTypeId,
            Type = tasteQuestionTypes.Type
        };
    }

    /**
     *
     * Delete a taste questions type based on the given id.
     *
     * @param id The id of the taste questions type to delete.
     * 
     */
    public void Delete(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var tasteQuestionTypes = context.TasteQuestionTypes.Find(id);

                if (tasteQuestionTypes == null)
                {
                    throw new ArgumentException("Error: That taste questions type does not exist!");
                }
                
                context.TasteQuestionTypes.Remove(tasteQuestionTypes);
                context.SaveChanges();
                
                // if everything is correct, just commit the transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                
                throw new Exception("Error: An error occurred while trying to delete the taste question type: " + ex.Message + "(" + ex.InnerException + ")");
            }
        }
    }
}