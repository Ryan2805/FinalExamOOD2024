using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace FinalExamOOD
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }


        // Navigation property
        public virtual ICollection<Booking> Bookings { get; set; }

        public Customer()
        {
            Bookings = new List<Booking>();
        }
        public Booking AddBooking(DateTime date)
        {
            var booking = Bookings.FirstOrDefault(b => b.BookingsDate.Date == date.Date);
            if (booking == null)
            {
                booking = new Booking
                {
                    BookingsDate = date.Date,
                    NumberOfParticipants = 40, // resteraunt capacity is 40
                    CustomerID = CustomerID,
                    Customer = this
                };
                Bookings.Add(booking);
            }
            return booking;
        }

        public string BookResteraunt(DateTime date, int AvailableSpace)
        {
            var booking = AddBooking(date);
            if (booking.NumberOfParticipants >= AvailableSpace)
            {
                booking.NumberOfParticipants -= AvailableSpace;
                return "Booking successful. Seats left: " + booking.NumberOfParticipants;
            }
            else
            {
                return "Not enough seats available. Seats left: " + booking.NumberOfParticipants;
            }
        }

    }
    public class Booking
    {
        public int BookingID { get; set; }

        public DateTime BookingsDate { get; set; }

        public int NumberOfParticipants { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

    }
    public class RestaurantData : DbContext
    {
        public RestaurantData(string dbName) : base(dbName) { }

        public RestaurantData() : this("OODExam_RyanDaly") { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
