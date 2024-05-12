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

        public async Task<BookingDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid booking id");
            }

            var data = await _bookingRepository.GetAllAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Booking with id = {id} does not exist");
            }

            return _mapper.Map<BookingDTO>(data);
        }

        public async Task<IList<BookingListDTO>> ListAsync()
        {
            var data = await _bookingRepository.ListAllAsync();
            return _mapper.Map<IList<BookingListDTO>>(data);
        }

        public async Task<int> AddAsync(AddBookingRequest booking)
        {
            ValidateBooking(booking);

            return await _bookingRepository.AddAsync(_mapper.Map<BookingEntity>(booking));
        }

        public async Task<int> UpdateAsync(UpdateBookingRequest booking)
        {
            ValidateBooking(_mapper.Map<AddBookingRequest>(booking));

            await GetAsync(booking.Id);

            return await _bookingRepository.UpdateAsync(_mapper.Map<BookingEntity>(booking));
        }

        public async Task<int> DeleteAsync(int id)
        {
            await GetAsync(id);

            return await _bookingRepository.DeleteAsync(id);
        }

        private void ValidateBooking(AddBookingRequest booking)
        {
            if (booking is null)
            {
                throw new ArgumentNullException(nameof(booking), "Booking is empty");
            }

            if (booking.DateStart < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Invalid start date of booking", nameof(booking.DateStart));
            }

            if (booking.DateEnd < booking.DateStart)
            {
                throw new ArgumentException("Invalid end date of booking", nameof(booking.DateEnd));
            }
        }
    }
}
