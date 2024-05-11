namespace BookingAPI.Data.EntityConfigurations
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(b => b.DateStart)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(b => b.DateEnd)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(b => b.Accommodation)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AccommodationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
