﻿namespace BookingAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookingEntity?> GetAsync(int id)
        {
            return await _context.Bookings
                 .Where(a => a.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<BookingEntity?> GetAsync(int clientId, int accommodationId)
        {
            return await _context.Bookings
                 .Where(a => a.ClientId == clientId)
                 .Where(a => a.AccommodationId == accommodationId)
                 .SingleOrDefaultAsync();
        }

        public async Task<BookingEntity?> GetAllAsync(int id)
        {
            return await _context.Bookings
                 .Where(a => a.Id == id)
                 .Include(a => a.Accommodation)
                 .Include(c => c.Client)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<BookingEntity>> ListAllAsync()
        {
            return await _context.Bookings
                .Include(c => c.Client)
                .Include(a => a.Accommodation)
                .ToListAsync();
        }

        public async Task<int> AddAsync(BookingEntity booking)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Bookings.AddAsync(booking);
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

        public async Task<int> UpdateAsync(BookingEntity booking)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(booking).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return booking.Id;
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
