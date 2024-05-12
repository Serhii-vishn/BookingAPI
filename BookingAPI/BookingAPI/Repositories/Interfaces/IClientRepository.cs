namespace BookingAPI.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<ClientEntity?> GetAsync(int id);
        Task<ClientEntity?> GetAsync(string phoneNumber);
        Task<ClientEntity?> GetAsync(string lastName, string firstName, DateOnly dateOfBirth);
        Task<ClientEntity?> GetAllAsync(int id);
        Task<IList<ClientEntity>> ListAsync();
        Task<IList<ClientEntity>> ListAllAsync();
        Task<int> AddAsync(ClientEntity client);
        Task<int> UpdateAsync(ClientEntity client);
        Task<int> DeleteAsync(int id);
    }
}
