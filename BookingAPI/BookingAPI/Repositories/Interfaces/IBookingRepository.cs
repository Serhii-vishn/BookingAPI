namespace BookingAPI.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<BookingEntity?> GetAsync(int id);
        Task<BookingEntity?> GetAllAsync(int id);
        Task<IList<BookingEntity>> ListAllAsync();
        Task<int> AddAsync(BookingEntity booking);
        Task<int> UpdateAsync(BookingEntity booking);
        Task<int> DeleteAsync(int id);
    }
}
