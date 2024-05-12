namespace BookingAPI.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IAccommodationRepository _accomodationRepository;
        private readonly IMapper _mapper;

        public AccommodationService(IAccommodationRepository accomodationRepository, IMapper mapper)
        {
            _accomodationRepository = accomodationRepository;
            _mapper = mapper;
        }

        public async Task<AccommodationDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid accommodation id");
            }

            var data = await _accomodationRepository.GetAllAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Accommodation with id = {id} does not exist");
            }

            return _mapper.Map<AccommodationDTO>(data);
        }

        public async Task<IList<AccommodationListDTO>> ListAsync()
        {
            var data = await _accomodationRepository.ListAsync();

            return _mapper.Map<IList<AccommodationListDTO>>(data);
        }

        public async Task<int> UpdateAsync(UpdateAccommodationRequest accommodation)
        {
            ValidateAccommodation(_mapper.Map<AddAccommodationRequest>(accommodation));

            await GetAsync(accommodation.Id);

            return await _accomodationRepository.UpdateAsync(_mapper.Map<AccommodationEntity>(accommodation));
        }

        public async Task<int> AddAsync(AddAccommodationRequest accommodation)
        {
            ValidateAccommodation(accommodation);

            var data = await _accomodationRepository.GetAsync(accommodation.Name);
            if (data != null)
            {
                throw new ArgumentException($"Accommodation with name = {accommodation.Name} already exists");
            }

            data = await _accomodationRepository.GetAsync(accommodation.Address, accommodation.City, accommodation.Country);
            if (data != null)
            {
                throw new ArgumentException($"Accommodation already exists");
            }

            return await _accomodationRepository.AddAsync(_mapper.Map<AccommodationEntity>(accommodation));
        }

        public async Task<int> DeleteAsync(int id)
        {
            await GetAsync(id);

            return await _accomodationRepository.DeleteAsync(id);
        }

        private void ValidateAccommodation(AddAccommodationRequest accommodation)
        {
            if (accommodation is null)
            {
                throw new ArgumentNullException(nameof(accommodation), "Accommodation is empty");
            }

            if (string.IsNullOrEmpty(accommodation.Name) || accommodation.Name.Length > 55)
            {
                throw new ArgumentException("Accommodation name is required and must be no more than 55 characters long.");
            }

            if (string.IsNullOrEmpty(accommodation.Address) || accommodation.Address.Length > 55)
            {
                throw new ArgumentException("Accommodation address is required and must be no more than 55 characters long.");
            }

            if (string.IsNullOrEmpty(accommodation.City) || accommodation.City.Length > 35)
            {
                throw new ArgumentException("City is required and must be no more than 35 characters long.");
            }

            if (string.IsNullOrEmpty(accommodation.Country) || accommodation.Country.Length > 35)
            {
                throw new ArgumentException("Country is required and must be no more than 35 characters long.");
            }

            accommodation.AccommodationType = accommodation.AccommodationType.ToUpper();

            if (string.IsNullOrEmpty(accommodation.AccommodationType) || accommodation.AccommodationType.Length > 15)
            {
                throw new ArgumentException("Accommodation type is required and must be no more than 15 characters long.");
            }
            else if (!Enum.TryParse(typeof(AccomodationTypes), accommodation.AccommodationType, out var accomodation) || !Enum.IsDefined(typeof(AccomodationTypes), accomodation))
            {
                throw new ArgumentException("Invalid accommodation", nameof(accommodation.AccommodationType));
            }

            if (accommodation.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0.");
            }
        }
    }
}
