namespace BookingAPI.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        Task<string> CreateJWTTokenAsync(IdentityUser user, List<string> roles);
    }
}
