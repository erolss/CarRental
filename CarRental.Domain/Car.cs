﻿using System;
using System.Collections.Generic;

namespace CarRental.Domain
{
    public class Car
    {
        public int Id { get; set; }
        
        public string RegistrationNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ManufacturingYear { get; set; }
        public bool Available { get; set; }

        public bool Deleted { get; set; }
        public ICollection<BookingCar> BookingCars { get; set; }

        public Car ()
        {
            Available = true;
            Deleted = false;
        }

    }
}
