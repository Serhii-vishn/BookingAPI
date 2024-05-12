namespace BookingAPI.Repositories.Interfaces
{
    public interface IAccommodationRepository
    {
        Task<AccommodationEntity?> GetAsync(int id);
        Task<AccommodationEntity?> GetAllAsync(int id);
        Task<IList<AccommodationEntity>> ListAsync();
        Task<int> AddAsync(AccommodationEntity accommodation);
        Task<int> UpdateAsync(AccommodationEntity accommodation);
        Task<int> DeleteAsync(int id);
    }
}
