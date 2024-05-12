namespace BookingAPI.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService clientService, ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint for retrieving a specific client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to retrieve.</param>
        /// <returns>ClientDTO containing the client information.</returns>
        [HttpGet]
        [Route("/client/{id}")]
        public async Task<ActionResult> GetBooking(int id)
        {
            try
            {
                var result = await _clientService.GetAsync(id);
                _logger.LogInformation($"Client whith id ={id} were received");
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
        /// Endpoint for retrieving a list of clients.
        /// </summary>
        /// <returns>ClientsListDTO, containing a list of clients with abbreviated information for the list.</returns>
        [HttpGet]
        [Route("/clients")]
        public async Task<ActionResult> GetClients()
        {
            try
            {
                var result = await _clientService.ListAsync();
                _logger.LogInformation($"Clients (count = {result.Count}) were received");
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
        /// Endpoint for adding a new client.
        /// </summary>
        /// <param name="addClientRequest">Client information to add.</param>
        /// <returns>ActionResult indicating the result of the operation.</returns>
        [HttpPost]
        [Route("/client")]
        public async Task<ActionResult> AddClient([FromForm] AddClientRequest addClientRequest)
        {
            try
            {
                var result = await _clientService.AddAsync(addClientRequest);
                _logger.LogInformation($"Client with id = {result} was added");
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
        /// Endpoint for updating a client.
        /// </summary>
        /// <param name="updateClientRequest">Updated client information.</param>
        /// <returns>ActionResult indicating the result of the operation.</returns>
        [HttpPut]
        [Route("/client")]
        public async Task<ActionResult> UpdateClient([FromForm] UpdateClientRequest updateClientRequest)
        {
            try
            {
                var result = await _clientService.UpdateAsync(updateClientRequest);
                _logger.LogInformation($"Client with id = {result} was updated");
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
        /// Endpoint for deleting a client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to delete.</param>
        /// <returns>ID deleted client</returns>
        [HttpDelete]
        [Route("/client/{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            try
            {
                var result = await _clientService.DeleteAsync(id);
                _logger.LogInformation($"Client whith id ={id} were deleted");
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
