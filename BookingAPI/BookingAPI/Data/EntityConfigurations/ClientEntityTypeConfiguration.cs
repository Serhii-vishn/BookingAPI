namespace BookingAPI.Data.EntityConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(u => u.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(u => u.Gender)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12)
                .IsFixedLength();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(u => new { u.LastName, u.FirstName, u.DateOfBirth })
                .IsUnique();

            builder.HasIndex(u => u.PhoneNumber)
                .IsUnique();
        }
    }
}
