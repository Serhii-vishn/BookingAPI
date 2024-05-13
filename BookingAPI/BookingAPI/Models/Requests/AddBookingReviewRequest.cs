namespace BookingAPI.Models.Requests
{
    public class AddBookingReviewRequest
    {
        public double Rating { get; set; }
        public string? Comment { get; set; }

        public int ClientId { get; set; }
        public int AccommodationId { get; set; }
    }
}
