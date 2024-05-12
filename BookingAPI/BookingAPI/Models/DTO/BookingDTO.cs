namespace BookingAPI.Models.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }

        public string ClientFullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string AccommodationName { get; set; } = null!;     
        public string AccommodationType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
