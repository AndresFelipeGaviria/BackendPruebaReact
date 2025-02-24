using AutoMapper;
using HotelManagement.Aplication;
using HotelManagement.Domain.Entities;
using HotelManagement.Infrastructure;
using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;
using HotelManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services.Implementations
{
    public class HotelSearchService : IHotelSearchService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelSearchService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HotelResponseDto>> SearchHotelsAsync(
            DateTime? checkIn, DateTime? checkOut, int? guests, string? city)
        {
            var query = _context.Hotels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(h => h.City.Contains(city));
            }

            if (checkIn.HasValue && checkOut.HasValue)
            {
                query = query.Where(h => h.Rooms.Any(r =>
                    r.Reservations.All(res =>
                        res.CheckOutDate <= checkIn.Value || res.CheckInDate >= checkOut.Value)
                ));
            }

            if (guests.HasValue)
            {
                query = query.Where(h => h.Rooms.Any(r => r.Capacity >= guests.Value));
            }

            var hotels = await query.ToListAsync();
            return _mapper.Map<IEnumerable<HotelResponseDto>>(hotels);
        }

        public async Task<List<Room>> GetAvailableRoomsAsync(Guid hotelId, DateTime checkIn, DateTime checkOut)
        {
            return await _context.Rooms
                .Where(r => r.HotelId == hotelId &&
                            !_context.Reservations.Any(res => res.RoomId == r.RoomId &&
                                                              (checkIn < res.CheckOutDate && checkOut > res.CheckInDate)))
                .ToListAsync();
        }


        public async Task<ReservationResponseDto> CreateReservationAsync(ReservationRequestDto request)
        {

            var room = await _context.Rooms
                .Include(r => r.Hotel) 
                .FirstOrDefaultAsync(r => r.RoomId == request.RoomId);

            if (room == null)
            {
                throw new Exception("La habitación seleccionada no existe.");
            }
           
                var traveler = new Traveler
                {
                    TravelerId =  Guid.NewGuid(),
                    FullName = request.Traveler.FullName, 
                    DocumentNumber = request.Traveler.Email,
                    DocumentType = request.Traveler.DocumentType,
                    PhoneNumber = request.Traveler.PhoneNumber,
                    Gender = "N/N",
                    Email = request.Traveler.Email,

                };

                _context.Travelers.Add(traveler);
                await _context.SaveChangesAsync();
            

       
            var reservation = new Reservation
            {
                ReservationId = Guid.NewGuid(),
                HotelId = request.HotelId,
                RoomId = request.RoomId,
                TravelerId = traveler.TravelerId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                NumberOfGuests = request.TotalGuests,
                Guests = request.Guests.Select(g => new Guest
                {
                    GuestId = Guid.NewGuid(),
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    BirthDate = g.BirthDate,
                    Gender = g.Gender,
                    DocumentType = g.DocumentType,
                    Email = "sin Email",
                    Phone = "0000000",
                    DocumentNumber = g.DocumentNumber,
                  
                }).ToList(),
                EmergencyContact = new EmergencyContact
                {
                    EmergencyContactId = Guid.NewGuid(),
                    TravelerId = traveler.TravelerId, 
                    FullName = request.EmergencyContact.FullName,
                    Phone = request.EmergencyContact.Phone
                }
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();


            var emailService = new EmailService();
            await emailService.SendEmailAsync(
                $"{traveler.Email}",
                "Confirmación de Reserva",
                "<h1>Su reserva ha sido confirmada</h1><p>Gracias por reservar con nosotros.</p>"
            );

            return new ReservationResponseDto
            {
                ReservationId = reservation.ReservationId,
                HotelName = room.Hotel.Name,
                RoomType = room.RoomType,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                TotalGuests = reservation.Guests.Count,
                EmergencyContact = _mapper.Map<EmergencyContactResponseDto>(reservation.EmergencyContact),
            };
        }

    }
}
