namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        /// <summary>
        /// Endpoint to register a new user.
        /// </summary>
        /// <param name="registerUser">The request object containing user registration details.</param>
        /// <returns>An ActionResult representing the outcome of the registration operation.</returns>
        [HttpPost]
        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register([FromForm] RegisterUserRequest registerUser)
        {
            try
            {
                var result = await _authService.RegisterUserAsync(registerUser);
                _logger.LogInformation($"User - {registerUser.Username} were registered");
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Endpoint for user login.
        /// </summary>
        /// <param name="loginUser">A request object containing the user's login details.</param
        /// <returns>ActionResult representing the result of the login operation and the JWT token</returns>.
        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> Login([FromForm] LoginUserRequest loginUser)
        {
            try
            {
                var result = await _authService.LoginUserAsync(loginUser);
                _logger.LogInformation($"User - {loginUser.Username} was logined");
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500);
            }
        }
    }
}
