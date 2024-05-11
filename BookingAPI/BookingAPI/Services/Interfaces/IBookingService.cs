namespace BookingAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IList<BookingListDTO>> ListAsync();
    }
}
