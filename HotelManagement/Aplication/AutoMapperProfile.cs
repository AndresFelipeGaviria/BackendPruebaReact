using AutoMapper;
using HotelManagement.Domain.Entities;
using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;

namespace HotelManagement.Aplication
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, HotelRequestDto>().ReverseMap();
            CreateMap<Hotel, HotelUpdateDto>().ReverseMap();
            CreateMap<Hotel, HotelWithReservationsDto>().ReverseMap();
            CreateMap<Hotel, HotelResponseDto>()
                 .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms)).ReverseMap();



            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, RoomRequestDto>().ReverseMap();
            CreateMap<Room, RoomResponseDto>().ReverseMap();
            CreateMap<Room, RoomUpdateDto>().ReverseMap();


            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationRequestDto>().ReverseMap();
            CreateMap<Reservation, ReservationResponseDto>()
              .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact)).ReverseMap();

            CreateMap<EmergencyContact, EmergencyContactDto>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactRequestDto>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactResponseDto>().ReverseMap();


            CreateMap<Guest, GuestsDto>().ReverseMap();
            CreateMap<Guest, GuestsRequestDto>().ReverseMap();
            CreateMap<Guest, GuestsResponseDto>().ReverseMap();

            CreateMap<Traveler, TravelerDto>().ReverseMap();
            CreateMap<Traveler, TravelerRequestDto>().ReverseMap();
            CreateMap<Traveler, TravelerResponseDto>().ReverseMap();

        }
    }
}
