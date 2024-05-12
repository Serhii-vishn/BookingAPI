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

        public async Task<int> AddAsync(AddBookingRequest request)
        {
            ValidateBooking(request);

            return await _bookingRepository.AddAsync(_mapper.Map<BookingEntity>(request));
        }

        private void ValidateBooking(AddBookingRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request), "Booking is empty");
            }

            if (request.DateStart < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Invalid start date of booking", nameof(request.DateStart));
            }

            if (request.DateEnd < request.DateStart)
            {
                throw new ArgumentException("Invalid end date of booking", nameof(request.DateEnd));
            }
        }
    }
}
