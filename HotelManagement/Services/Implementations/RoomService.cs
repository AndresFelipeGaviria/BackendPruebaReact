using AutoMapper;
using HotelManagement.Infrastructure;
using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;
using HotelManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelManagement.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RoomService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoomResponseDto> AddRoomToHotelAsync(Guid hotelId, RoomRequestDto roomDto)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.HotelId == hotelId);
            if (hotel == null)
            {
                throw new CustomException(
                    "Hotel no encontrado",
                    (int)HttpStatusCode.NotFound
                    );
            }

            var room = new Room
            {
                RoomId = Guid.NewGuid(),
                HotelId = hotelId,
                RoomType = roomDto.RoomType,
                BaseCost = roomDto.BaseCost,
                Taxes = roomDto.Taxes,
                IsAvailable = roomDto.IsAvailable,
                Capacity = roomDto.Capacity,
                Location = roomDto.Location
            };

            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoomResponseDto>(room);
        }

        public async Task UpdateRoomAsync(Guid roomId, RoomUpdateDto roomDto)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);
             
            if(existingRoom == null)
            {
                throw new CustomException("Room not found", (int)HttpStatusCode.NotFound);
            }
            _mapper.Map(roomDto, existingRoom);

            
            _context.Rooms.Update(existingRoom);
             await _context.SaveChangesAsync();
        }

        public async Task<bool> ToggleRoomAvailabilityAsync(Guid roomId)
        {
            
            return true;
        }
    }
}
