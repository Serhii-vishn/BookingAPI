namespace BookingAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<AccommodationEntity> Accommodations { get; set;}
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccomodationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityTypeConfiguration());

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Name = "Client",
                    NormalizedName = "Client".ToUpper()
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
