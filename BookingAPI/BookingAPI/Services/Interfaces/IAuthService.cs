namespace BookingAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(RegisterUserRequest registerUser);
        Task<LoginUserResponse> LoginUserAsync(LoginUserRequest loginUser);
    }
}
