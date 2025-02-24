using AutoMapper;
using HotelManagement.Domain.Entities;
using HotelManagement.Infrastructure;
using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;
using HotelManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelManagement.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelService(ApplicationDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Hotel> CreateHotelAsync(HotelRequestDto hotel)
        {

            var newHotel = new Hotel
            {
                HotelId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                IsActive = hotel.IsActive,
                Address = hotel.Address,
                Name = hotel.Name,
                City = hotel.City
                
            };

            _context.Hotels.Add(newHotel);
            await _context.SaveChangesAsync();
            return newHotel;
        }

        public async Task UpdateHotelAsync(Guid hotelId, HotelUpdateDto hotelDto)
        {
            var existingHotel = await _context.Hotels.FirstOrDefaultAsync(x => x.HotelId == hotelId);
            if (existingHotel == null)
                throw new CustomException("Hotel not found", (int)HttpStatusCode.NotFound);

            _mapper.Map(hotelDto, existingHotel);

            _context.Hotels.Update(existingHotel);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ToggleHotelStatusAsync(Guid hotelId)
        {
            return true;
        }

        public async Task<IEnumerable<HotelResponseDto>> GetAllHotelsAsync()
        {
            var query  = await _context.Hotels
                .Include(x => x.Rooms)
                .ToListAsync();

            return query.Select(x => _mapper.Map<HotelResponseDto>(x));  

        }

        public async Task<HotelResponseDto?> GetHotelByIdAsync(Guid hotelId)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.HotelId == hotelId);

            if (hotel == null)
                throw new CustomException("Hotel not found", (int)HttpStatusCode.NotFound);

            return _mapper.Map<HotelResponseDto>(hotel);
        }

        public async Task<List<HotelWithReservationsDto>> GetHotelsWithReservationsAsync()
        {
            return await _context.Hotels
                .Include(h => h.Reservations)
                .Select(h => new HotelWithReservationsDto
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Reservations = h.Reservations.Select(r => new ReservationResponseDto
                    {
                        ReservationId = r.ReservationId,
                        CheckInDate = r.CheckInDate,
                        CheckOutDate = r.CheckOutDate,
                        HotelId = r.HotelId,
                        RoomId = r.RoomId,
                        RoomType = r.Room.RoomType,
                        TotalGuests = r.NumberOfGuests,
                        EmergencyContact = _mapper.Map<EmergencyContactResponseDto>(r.EmergencyContact),
                        Room = _mapper.Map<RoomResponseDto>(r.Room),
                        Traveler = _mapper.Map<TravelerResponseDto>(r.Traveler),
                        
                    }).ToList()
                })
                .ToListAsync();
        }
    }

}
