namespace BookingAPI.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly ApplicationDbContext _context;

        public AccommodationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccommodationEntity?> GetAsync(int id)
        {
            return await _context.Accommodations
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<AccommodationEntity?> GetAsync(string name)
        {
            return await _context.Accommodations
                 .Where(a => string.Equals(a.Name, name))
                 .SingleOrDefaultAsync();
        }

        public async Task<AccommodationEntity?> GetAsync(string address, string city, string country)
        {
            return await _context.Accommodations
                .Where(a => string.Equals(a.Address, address))
                .Where(a => string.Equals(a.City, city))
                .Where(a => string.Equals(a.Country, country))
                .SingleOrDefaultAsync();
        }

        public async Task<AccommodationEntity?> GetAllAsync(int id)
        {
            return await _context.Accommodations
                 .Where(a => a.Id == id)
                 .Include(b => b.Bookings)
                 .Include(r => r.Reviews)
                    .ThenInclude(c => c.Client)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<AccommodationEntity>> ListAsync()
        {
            return await _context.Accommodations
                .ToListAsync();
        }

        public async Task<int> AddAsync(AccommodationEntity accommodation)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Accommodations.AddAsync(accommodation);
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

        public async Task<int> UpdateAsync(AccommodationEntity accommodation)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(accommodation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return accommodation.Id;
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
