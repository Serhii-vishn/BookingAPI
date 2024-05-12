namespace BookingAPI.Models.DTO
{
    public class ReviewsListDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public double Rating { get; set; }
        public string? Comment { get; set; }  
    }
}
