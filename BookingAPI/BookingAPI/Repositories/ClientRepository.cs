namespace BookingAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClientEntity?> GetAsync(int id)
        {
            return await _context.Clients
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<ClientEntity?> GetAsync(string phoneNumber)
        {
            return await _context.Clients
                 .Where(a => string.Equals(a.PhoneNumber, phoneNumber))
                 .SingleOrDefaultAsync();
        }

        public async Task<ClientEntity?> GetAsync(string lastName, string firstName, DateOnly dateOfBirth)
        {
            return await _context.Clients
                .Where(a => string.Equals(a.LastName, lastName))
                .Where(a => string.Equals(a.FirstName, firstName))
                .Where(a => a.DateOfBirth == dateOfBirth)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<ClientEntity>> ListAsync()
        {
            return await _context.Clients
                .ToListAsync();
        }

        public async Task<IList<ClientEntity>> ListAllAsync()
        {
            return await _context.Clients
                .Include(b => b.Bookings)
                    .ThenInclude(a => a.Accommodation)
                .ToListAsync();
        }

        public async Task<int> AddAsync(ClientEntity client)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return result.Entity.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> UpdateAsync(ClientEntity client)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(client).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return client.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry((await GetAsync(id))!).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
