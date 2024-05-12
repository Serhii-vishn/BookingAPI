namespace BookingAPI.Repositories.Interfaces
{
    public interface IAccommodationRepository
    {
        Task<AccommodationEntity?> GetAsync(int id);
        Task<AccommodationEntity?> GetAsync(string name);
        Task<AccommodationEntity?> GetAsync(string address, string city, string country);
        Task<AccommodationEntity?> GetAllAsync(int id);
        Task<IList<AccommodationEntity>> ListAsync();
        Task<int> AddAsync(AccommodationEntity accommodation);
        Task<int> UpdateAsync(AccommodationEntity accommodation);
        Task<int> DeleteAsync(int id);
    }
}
