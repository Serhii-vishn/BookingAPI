namespace BookingAPI.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingEntity, BookingListDTO>()
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.AccommodationName, opt => opt.MapFrom(src => src.Accommodation.Name))
                .ForMember(dest => dest.AccommodationType, opt => opt.MapFrom(src => src.Accommodation.AccommodationType));
        }
    }
}
