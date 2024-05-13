namespace BookingAPI.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<ReviewEntity?> GetAsync(int id);
        Task<int> AddAsync(ReviewEntity review);
        Task<int> DeleteAsync(int id);
    }
}
