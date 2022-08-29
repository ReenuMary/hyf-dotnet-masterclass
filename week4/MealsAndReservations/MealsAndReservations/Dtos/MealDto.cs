using System;
namespace MealsAndReservations.Dtos
{
	public record MealDto
	{
        public Guid Id { get; init; }
        public string? Title { get; set; }
        public decimal Cost { get; set; }
        public string? Location { get; set; }
        public int MaxReservations { get; set; }
    }
}

