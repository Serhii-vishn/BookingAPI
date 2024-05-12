namespace BookingAPI.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/bookings")]
        public async Task<ActionResult> GetBookings(string? filterOn, string? filterQuery)
        {
            try
            {
                var result = await _bookingService.ListAsync();
                _logger.LogInformation($"Bookings (count = {result.Count}) were received");
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

        [HttpPost]
        [Route("/booking")]
        public async Task<ActionResult> AddBooking([FromForm] AddBookingRequest addBookingRequest)
        {
            try
            {
                var result = await _bookingService.AddAsync(addBookingRequest);
                _logger.LogInformation($"Booking with id = {result} was added");
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
