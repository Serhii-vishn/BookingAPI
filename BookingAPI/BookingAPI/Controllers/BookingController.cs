﻿namespace BookingAPI.Controllers
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

        /// <summary>
        /// Endpoint for retrieving booking by its ID.
        /// </summary>
        /// <param name="id">ID of the booking to retrieve.</param>
        /// <returns>DTO containing the booking information.</returns>
        [HttpGet]
        [Route("/booking/{id}")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<ActionResult> GetBooking(int id)
        {
            try
            {
                var result = await _bookingService.GetAsync(id);
                _logger.LogInformation($"Booking whith id ={id} were received");
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
        /// Endpoint for retrieving a list of bookings with optional filtering.
        /// </summary>
        /// <param name="filterOn">Optional filter field.</param>
        /// <param name="filterQuery">Optional filter query.</param>
        /// <returns>List of bookings.</returns>
        [HttpGet]
        [Route("/bookings")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<ActionResult> GetBookings()
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

        /// <summary>
        /// Endpoint for adding a new booking.
        /// </summary>
        /// <param name="addBookingRequest">Booking information to add</param>
        /// <returns>Id of the newly added booking.</returns>
        [HttpPost]
        [Route("/booking")]
        [Authorize(Roles = "Client,Admin")]
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

        /// <summary>
        /// Endpoint for updating a booking.
        /// </summary>
        /// <param name="updateBookingRequest">Updated booking information.</param>
        /// <returns>ActionResult indicating the result of the operation.</returns>
        [HttpPut]
        [Route("/booking")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<ActionResult> UpdateBooking([FromForm] UpdateBookingRequest updateBookingRequest)
        {
            try
            {
                var result = await _bookingService.UpdateAsync(updateBookingRequest);
                _logger.LogInformation($"Booking with id = {result} was updated");
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
        /// Endpoint for deleting a booking by their ID.
        /// </summary>
        /// <param name="id">ID of the booking to delete.</param>
        /// <returns>ID deleted booking</returns>
        [HttpDelete]
        [Route("/booking/{id}")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            try
            {
                var result = await _bookingService.DeleteAsync(id);
                _logger.LogInformation($"Booking whith id ={id} were deleted");
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
