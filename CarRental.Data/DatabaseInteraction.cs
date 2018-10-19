using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public static class DatabaseInteraction
    {
        public static CarRentalContext context = new CarRentalContext();

        public static void AddCustomer (Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
       
        

        /// <summary>
        /// Finds a customer based on customerId, 
        /// includes the customers bookings since we want to
        /// delete the bookings connected to a specific customer
        /// when we delete the customer himself.
        /// Then we loop through the list of customer bookings and delete the BookingCar posts 
        /// connected to those bookings. After that we can remove all bookings as well as the
        /// customer himself. 
        /// </summary>
        /// <param name="customerId"></param>
        public static void DeleteCustomer(int customerId)
        {
            Customer customer = context.Customers.Include(c => c.Bookings)
                                            .Where(c => c.Id == customerId).FirstOrDefault();
            foreach (var b in customer.Bookings)
            {
                List<BookingCar> bookingCars = context.BookingCars.Where(booking => booking.BookingId == b.Id).ToList();
                context.BookingCars.RemoveRange(bookingCars);
            }

            context.Bookings.RemoveRange(customer.Bookings);
            context.Customers.Remove(customer);
        }

        /// <summary>
        /// Method that updates a customer object and saves the
        /// updated data to the database. Which fields are updated
        /// are not relevant in this step.
        /// </summary>
        /// <param name="customer"></param>
        public static void UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);

            context.SaveChanges();
        }

        public static void AddCar (Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        /// <summary>
        /// Changes the value of the car-property "Deleted" to true,
        /// doesn't explicitly remove the car from the database.
        /// </summary>
        /// <param name="carId"></param>
        public static void DeleteCar(int carId)
        {
            var carToDelete = context.Cars.Where(c => c.Id == carId).FirstOrDefault();


           // carToDelete.Deleted = true;
            context.Cars.Update(carToDelete);
            context.SaveChanges();
        }


        /// <summary>
        /// Finds all posts in BookingCar-table, deletes all posts related to given bookingID.
        /// After that, deletes the actual booking.
        /// </summary>
        /// <param name="bookingId">ID of the booking to delete</param>
        public static void DeleteBooking(int bookingId)
        {
            List<BookingCar> listOfbookingsForCar = context.BookingCars.Where(bc => bc.BookingId == bookingId).ToList();
            context.BookingCars.RemoveRange(listOfbookingsForCar);
            var bookingToDelete = context.Bookings.Where(b => b.Id == bookingId).FirstOrDefault();

            context.Bookings.Remove(bookingToDelete);
            context.SaveChanges();
        }

    }
}
