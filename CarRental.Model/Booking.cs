using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Model
{
    public class Booking
    {
        public int Id { get; set; }

        public Customer BookingCustomer { get; set; }
        public int CustomerId { get; set; }
            
        ICollection<Car> Cars { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
