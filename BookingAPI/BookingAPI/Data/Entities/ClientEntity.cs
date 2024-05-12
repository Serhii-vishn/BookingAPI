namespace BookingAPI.Data.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PictureFileName { get; set; }

        public IList<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();

        public IList<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    }
}
