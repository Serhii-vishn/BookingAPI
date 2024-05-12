namespace BookingAPI.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class AccommodationController : Controller
    {
        private readonly IAccommodationService _accomodationService;
        private readonly ILogger<AccommodationController> _logger;

        public AccommodationController(IAccommodationService accomodationService, ILogger<AccommodationController> logger)
        {
            _accomodationService = accomodationService;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint for retrieving accommodation by ID.
        /// </summary>
        /// <param name="id">ID of the accommodation to retrieve.</param>
        /// <returns>AccomodationDTO containing the accommodation information.</returns>
        [HttpGet]
        [Route("/accommodation/{id}")]
        public async Task<ActionResult> GetAccommodation(int id)
        {
            try
            {
                var result = await _accomodationService.GetAsync(id);
                _logger.LogInformation($"Accommodation whith id ={id} were received");
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
        /// Endpoint for retrieving a list of accommodations.
        /// </summary>
        /// <returns>AccomodationListDTO containing the list of accommodations.</returns>
        [HttpGet]
        [Route("/accommodations")]
        public async Task<ActionResult> GetAccommodations()
        {
            try
            {
                var result = await _accomodationService.ListAsync();
                _logger.LogInformation($"Accomodations (count = {result.Count}) were received");
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
        /// Endpoint for adding a new accommodation.
        /// </summary>
        /// <param name="addAccommodationRequest">Accommodation information to add.</param>
        /// <returns>ActionResult indicating the result of the operation.</returns>
        [HttpPost]
        [Route("/accommodation")]
        public async Task<ActionResult> AddAccommodation([FromForm] AddAccommodationRequest addAccommodationRequest)
        {
            try
            {
                var result = await _accomodationService.AddAsync(addAccommodationRequest);
                _logger.LogInformation($"Accommodation with id = {result} was added");
                return Ok();
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
        /// Endpoint for updating a accommodation.
        /// </summary>
        /// <param name="updateAccommodationRequest">Updated accommodation information.</param>
        /// <returns>ActionResult indicating the result of the operation.</returns>
        [HttpPut]
        [Route("/accommodation")]
        public async Task<ActionResult> UpdateAccommodation([FromForm] UpdateAccommodationRequest updateAccommodationRequest)
        {
            try
            {
                var result = await _accomodationService.UpdateAsync(updateAccommodationRequest);
                _logger.LogInformation($"Accommodation with id = {result} was updated");
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
        /// Endpoint for deleting a accommodation by their ID.
        /// </summary>
        /// <param name="id">ID of the accommodation to delete.</param>
        /// <returns>ID deleted accommodation</returns>
        [HttpDelete]
        [Route("/accommodation/{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            try
            {
                var result = await _accomodationService.DeleteAsync(id);
                _logger.LogInformation($"Accommodation whith id ={id} were deleted");
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
