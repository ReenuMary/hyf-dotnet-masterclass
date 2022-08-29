using System;
namespace MealsAndReservations.Models
{
	public record Meal
	{
        public Guid Id { get; init; }
        public string? Title { get; set; }
        public decimal Cost { get; set; }
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
        public int MaxReservations { get; set; }

    }
}

