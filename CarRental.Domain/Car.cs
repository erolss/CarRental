using System;

namespace CarRental.Domain
{
    public class Car
    {
        public int Id { get; set; }
        
        public string RegistrationNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingYear { get; set; }

    }
}
