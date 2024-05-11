namespace BookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<IList<BookingListDTO>> ListAsync()
        {
            var data = await _bookingRepository.ListAllAsync();

            return _mapper.Map<IList<BookingListDTO>>(data);
        }
    }
}
