﻿namespace BookingAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid client id");
            }

            var data = await _clientRepository.GetAllAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Client with id = {id} does not exist");
            }

            return _mapper.Map<ClientDTO>(data);
        }

        public async Task<IList<ClientListDTO>> ListAsync()
        {
            var data = await _clientRepository.ListAsync();

            return _mapper.Map<IList<ClientListDTO>>(data);
        }

        public async Task<int> AddAsync(AddClientRequest client)
        {
            ValidateClient(client);

            var data = await _clientRepository.GetAsync(client.PhoneNumber);
            if (data != null)
            {
                throw new ArgumentException($"Client with phone = {client.PhoneNumber} already exists");
            }

            data = await _clientRepository.GetAsync(client.LastName, client.FirstName, client.DateOfBirth);
            if (data != null)
            {
                throw new ArgumentException($"Client already exists");
            }

            return await _clientRepository.AddAsync(_mapper.Map<ClientEntity>(client));
        }
        
        public async Task<int> UpdateAsync(UpdateClientRequest client)
        {
            ValidateClient(_mapper.Map<AddClientRequest>(client));

            await GetAsync(client.Id);

            return await _clientRepository.UpdateAsync(_mapper.Map<ClientEntity>(client));
        }

        public async Task<int> DeleteAsync(int id)
        {
            await GetAsync(id);

            return await _clientRepository.DeleteAsync(id);
        }

        private void ValidateClient(AddClientRequest client)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client), "Client is empty");
            }

            if (string.IsNullOrEmpty(client.FirstName) || client.FirstName.Length > 55)
            {
                throw new ArgumentException("FirstName is required and should be maximum 55 characters long", nameof(client.FirstName));
            }

            if (string.IsNullOrEmpty(client.LastName) || client.LastName.Length > 55)
            {
                throw new ArgumentException("LastName is required and should be maximum 55 characters long", nameof(client.FirstName));
            }

            if (client.DateOfBirth < DateOnly.Parse("1930-01-01"))
            {
                throw new ArgumentException("Invalid date of bith", nameof(client.DateOfBirth));
            }

            client.Gender = client.Gender.ToUpper();

            if (string.IsNullOrEmpty(client.Gender) || client.Gender.Length > 7)
            {
                throw new ArgumentException("Gender is required and should be maximum 7 characters long", nameof(client.Gender));
            }
            else if (!Enum.TryParse(typeof(Genders), client.Gender, out var gender) || !Enum.IsDefined(typeof(Genders), gender))
            {
                throw new ArgumentException("Invalid gender", nameof(client.Gender));
            }

            if (string.IsNullOrWhiteSpace(client.PhoneNumber))
            {
                throw new ArgumentNullException(nameof(client.PhoneNumber), "Phone number is empty");
            }
            else
            {
                client.PhoneNumber = client.PhoneNumber.Trim();

                const string ukrainianPhoneNumberPattern = @"^380\d{9}$";

                if (!Regex.IsMatch(client.PhoneNumber, ukrainianPhoneNumberPattern))
                {
                    throw new ArgumentException(nameof(client.PhoneNumber), "Phone number is invalid");
                }
            }

            if (string.IsNullOrWhiteSpace(client.Email) || client.Email.Length > 30)
            {
                throw new ArgumentException("Email is required and should be maximum 30 characters long", nameof(client.Email));
            }
        }
    }
}
