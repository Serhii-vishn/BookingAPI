namespace BookingAPI.Models.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }

        public int ClientId { get; set; }
        public int AccommodationId { get; set; }
    }
}
