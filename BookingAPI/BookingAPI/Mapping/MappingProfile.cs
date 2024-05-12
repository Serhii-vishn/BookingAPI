namespace BookingAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingEntity, AddBookingRequest>()
                .ReverseMap();

            CreateMap<BookingEntity, BookingListDTO>()
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.AccommodationName, opt => opt.MapFrom(src => src.Accommodation.Name))
                .ForMember(dest => dest.AccommodationType, opt => opt.MapFrom(src => src.Accommodation.AccommodationType));

            CreateMap<ClientEntity, ClientDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

            CreateMap<ClientEntity, ClientListDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

            CreateMap<AddClientRequest, ClientEntity>();

            CreateMap<UpdateClientRequest, ClientEntity>();

            CreateMap<AddClientRequest, UpdateClientRequest>()
                .ReverseMap();
        }
    }
}
