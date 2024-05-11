namespace BookingAPI.Data.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }

        public int ClientId { get; set; }
        public ClientEntity Client { get; set; } = null!;

        public int BookingId { get; set; }
        public BookingEntity Booking { get; set; } = null!;
    }
}
