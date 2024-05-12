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

        [HttpPost]
        [Route("/client")]
        public async Task<ActionResult> AddClient([FromForm] AddClientRequest addclientRequest)
        {
            try
            {
                var result = await _clientService.AddAsync(addclientRequest);
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
    }
}
