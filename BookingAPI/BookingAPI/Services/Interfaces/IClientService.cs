namespace BookingAPI.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO> GetAsync(int id);
        Task<IList<ClientListDTO>> ListAsync();
        Task<int> AddAsync(AddClientRequest request);
        Task<int> UpdateAsync(UpdateClientRequest request);
        Task<int> DeleteAsync(int id);
    }
}
