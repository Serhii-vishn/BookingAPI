namespace BookingAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDTO> GetAsync(int id);
        Task<IList<BookingListDTO>> ListAsync();
        Task<int> AddAsync(AddBookingRequest request);
        Task<int> UpdateAsync(UpdateBookingRequest request);
        Task<int> DeleteAsync(int id);
    }
}
