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

            CreateMap<AddClientRequest, ClientEntity>();
        }
    }
}
