﻿namespace BookingAPI.Data.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }

        public int UserId { get; set; }
        public ClientEntity User { get; set; } = null!;

        public int BookingId { get; set; }
        public BookingEntity Booking { get; set; } = null!;
    }
}
