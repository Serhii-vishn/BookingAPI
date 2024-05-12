namespace BookingAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Review mappings
            CreateMap<ReviewEntity, ReviewsListDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"));
            #endregion

            #region Booking mappings
            CreateMap<BookingEntity, AddBookingRequest>()
                .ReverseMap();

            CreateMap<BookingEntity, BookingListDTO>()
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.AccommodationName, opt => opt.MapFrom(src => src.Accommodation.Name))
                .ForMember(dest => dest.AccommodationType, opt => opt.MapFrom(src => src.Accommodation.AccommodationType));
            #endregion

            #region Accomodation mappings
            CreateMap<AccommodationEntity, AccommodationDTO>()
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews.ToList()))
                .ReverseMap();

            CreateMap<AccommodationEntity, AccommodationListDTO>()
                .ReverseMap();
            #endregion

            #region Client mappings
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
            #endregion
        }
    }
}
