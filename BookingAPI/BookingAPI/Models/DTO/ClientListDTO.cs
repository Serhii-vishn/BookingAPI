namespace BookingAPI.Models.DTO
{
    public class ClientListDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? PictureFileName { get; set; }
    }
}
