namespace BookingAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewEntity?> GetAsync(int id)
        {
            return await _context.Reviews
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(ReviewEntity review)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Reviews.AddAsync(review);
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
