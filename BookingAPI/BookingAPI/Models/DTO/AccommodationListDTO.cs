namespace BookingAPI.Models.DTO
{
    public class AccommodationListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string AccommodationType { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
