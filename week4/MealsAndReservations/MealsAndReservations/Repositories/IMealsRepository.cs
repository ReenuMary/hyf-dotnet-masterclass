using MealsAndReservations.Models;

namespace MealsAndReservations.Repositories
{
    public interface IMealsRepository
    {
        Task<Meal?> GetMealByIdAsync(Guid id);
        Task<List<Meal>> GetMealsAsync();
        Task CreateMealAsync(Meal meal);
        Task UpdateMealAsync( Meal meal);
        Task DeleteMealAsync(Guid id);
    }
}