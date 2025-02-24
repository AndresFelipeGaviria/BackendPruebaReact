namespace HotelManagement.Models.Entities
{
    public class Guest
    {
        public Guid GuestId { get; set; }
        public Guid ReservationId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Reservation Reservation { get; set; }
    }
}
