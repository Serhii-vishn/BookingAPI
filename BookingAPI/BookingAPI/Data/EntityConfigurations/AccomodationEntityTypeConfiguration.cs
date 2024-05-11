namespace BookingAPI.Data.EntityConfigurations
{
    public class AccomodationEntityTypeConfiguration : IEntityTypeConfiguration<AccommodationEntity>
    {
        public void Configure(EntityTypeBuilder<AccommodationEntity> builder)
        {
            builder.ToTable("Accommodations");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(a => a.AccommodationType)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(a => a.Description)
                .HasMaxLength(110);

            builder.HasIndex(a => new { a.Address, a.City, a.Country })
                .IsUnique();

            builder.HasIndex(a => a.Name)
                .IsUnique();
        }
    }
}
