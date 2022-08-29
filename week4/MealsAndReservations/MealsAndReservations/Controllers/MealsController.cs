using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsAndReservations.Dtos;
using MealsAndReservations.Models;
using MealsAndReservations.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MealsAndReservations.Extensions;

namespace MealsAndReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealsRepository mealsRepository;

        public MealsController(IMealsRepository repository)
        {
            mealsRepository = repository;
        }

        // GET: api/Meals
        [HttpGet]
        public async Task<IEnumerable<MealDto>> GetMealsAsync()
        {
            var meals = (await mealsRepository.GetMealsAsync()).Select(x => x.AsDto());
            return meals;                                     
        }

       // GET: api/Meals/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult< MealDto >>GetMealByIdAsync(Guid id)
        {
           var meal= await mealsRepository.GetMealByIdAsync(id);
            if(meal ==null )
            {
                return NotFound();
            }
            return Ok(meal.AsDto());

        }
    

       // POST: api/Meals
        [HttpPost]
        public async Task<ActionResult<MealDto>> PostAsync ([FromBody] CreateMealDto createMealDto)
        {
            var meal = new Meal()
            {
                Id=Guid.NewGuid(),
                Title =createMealDto.Title,
                Cost=createMealDto.Cost,
                Location=createMealDto.Location,
                MaxReservations =createMealDto.MaxReservations
            };

            await mealsRepository.CreateMealAsync(meal);
            return Ok(meal.AsDto());
        }


        
       // PUT: api/Meals/5
       [HttpPut("{id}")]
       public async Task<ActionResult> Put(Guid id, [FromBody] UpdateMealDto updateMealDto)
       {
            var meal =await mealsRepository.GetMealByIdAsync(id);
            if(meal == null)
            {
                return NotFound();
            }
            var updatedMeal = meal with
            {
                MaxReservations = updateMealDto.MaxReservations,
                Cost = updateMealDto.Cost,
                Location = updateMealDto.Location
            };

            await mealsRepository.UpdateMealAsync(updatedMeal);
            return NoContent();
       }
        
        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var meal =await mealsRepository.GetMealByIdAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

           await mealsRepository.DeleteMealAsync(id);
            return NoContent();
        }
    }
}
