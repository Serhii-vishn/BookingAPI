namespace BookingAPI.Services.Interfaces
{
    public interface IAccommodationService
    {
        Task<AccommodationDTO> GetAsync(int id);
        Task<IList<AccommodationListDTO>> ListAsync();
        Task<int> AddAsync(AddAccommodationRequest request);
        Task<int> UpdateAsync(UpdateAccommodationRequest request);
        Task<int> DeleteAsync(int id);
    }
}
