namespace BookingAPI.Services.Interfaces
{
    public interface IReviewService
    {
        Task<int> AddAsync(AddBookingReviewRequest request, int accommodationId);
        Task<int> DeleteAsync(int accomodationId, int reviewId);
    }
}
