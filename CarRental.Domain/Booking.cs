using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
    public class Booking
    {
        public int Id { get; set; }

        public Customer BookingCustomer { get; set; }
        public int CustomerId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<BookingCar> BookingCars { get; set; }
    }
}
