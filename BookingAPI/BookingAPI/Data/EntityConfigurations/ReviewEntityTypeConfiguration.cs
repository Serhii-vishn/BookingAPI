namespace BookingAPI.Data.EntityConfigurations
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(110);

            builder.HasOne(r => r.Client)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Accommodation) 
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.AccommodationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
