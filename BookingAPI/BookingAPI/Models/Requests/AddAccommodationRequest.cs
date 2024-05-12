namespace BookingAPI.Models.Requests
{
    public class AddAccommodationRequest
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string AccommodationType { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
