using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
    public class BookingCar
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public Booking Booking { get; set; }
        public Car Car { get; set; }
    }
}
