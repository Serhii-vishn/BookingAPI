namespace BookingAPI.Models.DTO
{
    public class BookingListDTO
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string ClientFullName { get; set; } = null!;
        public string AccommodationName { get; set; } = null!;
        public string AccommodationType { get; set; } = null!;
    }
}
