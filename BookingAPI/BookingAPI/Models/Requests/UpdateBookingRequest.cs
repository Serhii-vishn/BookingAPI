namespace BookingAPI.Models.Requests
{
    public class UpdateBookingRequest
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }

        public int ClientId { get; set; }
        public int AccommodationId { get; set; }
    }
}
