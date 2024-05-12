namespace BookingAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IList<BookingListDTO>> ListAsync();
        Task<int> AddAsync(AddBookingRequest request);
    }
}
