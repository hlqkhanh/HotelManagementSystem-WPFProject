using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class CustomerDAO
    {
        private static readonly List<Customer> customers = new List<Customer>
        {
            //new Customer { CustomerID = 3, CustomerFullName = "William Shakespeare", Telephone = "0903939393", EmailAddress = "WilliamShakespeare@FUMiniHotel.org", CustomerBirthday = new DateTime(1990, 2, 2), CustomerStatus = 1, Password = "123@" },
            new Customer { CustomerID = 3, CustomerFullName = "William Shakespeare", Telephone = "0903939393", EmailAddress = "2", CustomerBirthday = new DateTime(1990, 2, 2), CustomerStatus = 1, Password = "2" },
            new Customer { CustomerID = 5, CustomerFullName = "Elizabeth Taylor", Telephone = "0903939377", EmailAddress = "ElizabethTaylor@FUMiniHotel.org", CustomerBirthday = new DateTime(1991, 3, 3), CustomerStatus = 1, Password = "144@" },
            new Customer { CustomerID = 8, CustomerFullName = "James Cameron", Telephone = "0903946582", EmailAddress = "JamesCameron@FUMiniHotel.org", CustomerBirthday = new DateTime(1992, 11, 10), CustomerStatus = 1, Password = "443@" },
            new Customer { CustomerID = 9, CustomerFullName = "Charles Dickens", Telephone = "0903955633", EmailAddress = "CharlesDickens@FUMiniHotel.org", CustomerBirthday = new DateTime(1991, 12, 5), CustomerStatus = 1, Password = "563@" },
            new Customer { CustomerID = 10, CustomerFullName = "George Orwell", Telephone = "0913933493", EmailAddress = "GeorgeOrwell@FUMiniHotel.org", CustomerBirthday = new DateTime(1993, 12, 24), CustomerStatus = 1, Password = "177@" },
            new Customer { CustomerID = 11, CustomerFullName = "Victoria Beckham", Telephone = "0983246773", EmailAddress = "VictoriaBeckham@FUMiniHotel.org", CustomerBirthday = new DateTime(1990, 9, 9), CustomerStatus = 1, Password = "654@" }
        };

        public static List<Customer> GetAll()
        {
            List<Customer> cusList = new List<Customer>();

            foreach (Customer c in customers.ToList())
            {
                c.BookingReservations = BookingReservationDAO.GetBookingReservationsByCustomerID(c.CustomerID);
                cusList.Add(c);
            }

            return cusList;
        }

        public static void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public static void Update(Customer customer)
        {
            foreach (Customer c in customers.ToList())
            {
                if (c.CustomerID == customer.CustomerID)
                {
                    c.CustomerFullName = customer.CustomerFullName;
                    c.Telephone = customer.Telephone;
                    c.EmailAddress = customer.EmailAddress;
                    c.CustomerBirthday = customer.CustomerBirthday;
                }
            }

        }

        public static void Delete(Customer customer)
        {
            foreach (Customer c in customers.ToList())
            {
                if (c.CustomerID == customer.CustomerID)
                {
                    customers.Remove(c);
                }
            }
        }


        public static Customer? CheckLogin(string email, string password)
        {
            foreach(Customer c in customers.ToList())
            {
                if (c.EmailAddress.Equals(email) && c.Password.Equals(password))
                    return c;
            }
            return null;
        }
    }
}
