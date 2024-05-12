namespace BookingAPI.Models.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PictureFileName { get; set; }

        public IList<BookingListDTO> Bookings { get; set; } = new List<BookingListDTO>();
        public IList<ReviewsListDTO> Reviews { get; set; } = new List<ReviewsListDTO>();
    }
}
