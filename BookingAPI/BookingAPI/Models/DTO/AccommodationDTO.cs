﻿namespace BookingAPI.Models.DTO
{
    public class AccommodationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string AccommodationType { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public IList<ReviewsListDTO> Reviews { get; set; } = new List<ReviewsListDTO>();
    }
}
