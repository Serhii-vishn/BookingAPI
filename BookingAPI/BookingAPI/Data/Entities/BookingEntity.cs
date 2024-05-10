﻿namespace BookingAPI.Data.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public int AccommodationId { get; set; }
        public AccommodationEntity Accommodation { get; set; } = null!;
    }
}