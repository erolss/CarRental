using CarRental.Data;
using CarRental.Domain;
using System;
using System.Linq;

namespace CarRental.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();

            var customers = repo.DataSet<Customer>().ToList();
            var cars = repo.DataSet<Car>().ToList();
            var bookings = repo.DataSet<Booking>().ToList();


            repo.AddRange(new[] {
                new Customer
            {
                FirstName = "Pelle",
                LastName = "Kanin",
                Email = "pelle@kanin.com",
                PhoneNumber = "123123123",
            },
                new Customer
            {
                FirstName = "Gert",
                LastName = "Bert",
                Email = "gert@kanin.com",
                PhoneNumber = "999123123",
            }
            });
            repo.AddRange(new[] {
            new Car{
                RegistrationNo = "ABC123",
                Brand = "Volvo",
                ManufacturingYear = 2018,
                Model ="V90"
            },
            new Car {
                RegistrationNo = "DEF456",
                Brand = "Volkswagen",
                ManufacturingYear = 2018,
                Model ="Passat"
            }
            }
            );
            repo.SaveChanges();

            repo.Add(new Booking
            {
                CustomerId = repo.DataSet<Customer>().Where(c => c.FirstName == "Pelle").Select(c => c.Id).Single(),
                StartTime = new DateTime(2018, 11, 01),
                EndTime = new DateTime(2018, 11, 03),

                //BookingCars = new Booking = repo.DataSet<Car>().Where(c => c.RegistrationNo == "ABC123").ToList();
            });
            repo.SaveChanges();
            var booking = repo.DataSet<Booking>().Where(b => b.BookingCustomer.FirstName == "Pelle").FirstOrDefault();

            booking.BookingCars = new[] {
                new BookingCar
                {
                    Booking = booking,
                    Car = repo.DataSet<Car>().Single(c => c.RegistrationNo == "ABC123")
                }
            };

            repo.SaveChanges();


            //customers = repo.DataSet<Customer>().ToList();
            //cars = repo.DataSet<Car>().ToList();
            //bookings = repo.DataSet<Booking>().ToList();

            //var bookingFirstName = repo.DataSet<Booking>().Where(b => b.Id == 1).Select(b => b.BookingCustomer.FirstName).Single().ToString();
            //var startDate = new DateTime(2018, 11, 02);
            //var endDate = new DateTime(2018, 11, 04);

            //var availableCars = repo.DataSet<Booking>()
            //    .Where(b=>!(b.StartTime < endDate && b.EndTime > startDate))
            //    .Select(c=>c)

            //var book = repo.DataSet<Booking>().Where(b => b.Id == 2).Single();

            //repo.Remove(book);
            //repo.SaveChanges();

            var cust = repo.DataSet<Customer>().ToList();
                
                //.Where(b=>!(b.Booking.StartTime < endDate && b.Booking.EndTime > startDate))
                    
        }
    }
}
