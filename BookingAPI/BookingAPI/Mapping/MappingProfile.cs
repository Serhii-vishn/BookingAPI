﻿namespace BookingAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Review mappings
            CreateMap<ReviewDTO, ReviewEntity>()
                .ReverseMap();

            CreateMap<AddBookingReviewRequest, ReviewEntity>()
                .ReverseMap();

            CreateMap<ReviewEntity, ReviewsListDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"));
            #endregion

            #region Booking mappings
            CreateMap<BookingEntity, BookingDTO>()
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Client.PhoneNumber))
                .ForMember(dest => dest.AccommodationName, opt => opt.MapFrom(src => src.Accommodation.Name))
                .ForMember(dest => dest.AccommodationType, opt => opt.MapFrom(src => src.Accommodation.AccommodationType))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Accommodation.Address))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Accommodation.Price))
                .ReverseMap();

            CreateMap<BookingEntity, BookingListDTO>()
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.AccommodationName, opt => opt.MapFrom(src => src.Accommodation.Name))
                .ForMember(dest => dest.AccommodationType, opt => opt.MapFrom(src => src.Accommodation.AccommodationType));

            CreateMap<AddBookingRequest, BookingEntity>()
                .ReverseMap();

            CreateMap<UpdateBookingRequest, BookingEntity>()
                .ReverseMap();

            CreateMap<AddBookingRequest, UpdateBookingRequest>()
                .ReverseMap();
            #endregion

            #region Accomodation mappings
            CreateMap<AccommodationEntity, AccommodationDTO>()
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews.ToList()))
                .ReverseMap();

            CreateMap<AccommodationEntity, AccommodationListDTO>()
            .ReverseMap();

            CreateMap<UpdateAccommodationRequest, AccommodationEntity>()
                .ReverseMap();

            CreateMap<AddAccommodationRequest, AccommodationEntity>()
                .ReverseMap();

            CreateMap<AddAccommodationRequest, UpdateAccommodationRequest>()
                .ReverseMap();
            #endregion

            #region Client mappings
            CreateMap<ClientEntity, ClientDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

            CreateMap<ClientEntity, ClientListDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

            CreateMap<AddClientRequest, ClientEntity>()
                .ReverseMap();

            CreateMap<UpdateClientRequest, ClientEntity>()
                .ReverseMap();

            CreateMap<AddClientRequest, UpdateClientRequest>()
                .ReverseMap();
            #endregion
        }
    }
}
