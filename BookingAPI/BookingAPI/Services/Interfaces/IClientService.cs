namespace BookingAPI.Services.Interfaces
{
    public interface IClientService
    {
        Task<int> AddAsync(AddClientRequest request);
    }
}
