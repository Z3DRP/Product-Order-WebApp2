using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OdersWebApp.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuild)
        {
            // Customer table
            modelBuild.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    FirstName = "Mojo",
                    LastName = "Jojo",
                    PhoneNumber = "712-909-1207",
                    EmailAddress = "MoJoJOJO1@example.com",
                    Street = "143 Brentwood",
                    City = "Arlington",
                    State = "Texas",
                    Zipcode = "90938"
                },
                new Customer
                {
                    CustomerID = 2,
                    FirstName = "Kevin",
                    LastName = "Hall",
                    PhoneNumber = "314-884-1035",
                    EmailAddress = "KHalls@example.com",
                    Street = "909 Acton",
                    City = "Festus",
                    State = "Missouri",
                    Zipcode = "73644"
                },
                new Customer
                {
                    CustomerID = 3,
                    FirstName = "Tenton",
                    LastName = "Argusta",
                    PhoneNumber = "618-435-8765",
                    EmailAddress = "Tman29@example.com",
                    Street = "214 Edwardston",
                    City = "Wood River",
                    State = "Illinois",
                    Zipcode = "62002"
                },
                new Customer
                {
                    CustomerID = 4,
                    FirstName = "Steve",
                    LastName = "O",
                    PhoneNumber = "948-492-0394",
                    EmailAddress = "SteveO@example.com",
                    Street = "84 Da street",
                    City = "Da Hood",
                    State = "Missouri",
                    Zipcode = "74893"
                },
                new Customer
                {
                    CustomerID = 5,
                    FirstName = "Anthoney",
                    LastName = "Holmes",
                    PhoneNumber = "314-988-5575",
                    EmailAddress = "AHolmes@example.com",
                    Street = "123 Something",
                    City = "Warrenton",
                    State = "Missouri",
                    Zipcode = "28273"
                }
            );
            // Products table
            modelBuild.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    Name = "Bonsi Tree",
                    Description = "A traditional japaneese Bonsi Tree",
                    UnitPrice = 19.99,
                    Image = "bonsiTree.jpg"
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Banana Dog",
                    Description = "A banana that is a dog",
                    UnitPrice = 100.99,
                    Image = "bananaDog.jpg"
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Chicken",
                    Description = "A friendly chicken",
                    UnitPrice = 2.75,
                    Image = "chicken.jpg"
                },
                new Product
                {
                    ProductID = 4,
                    Name = "Digitl Clock",
                    Description = "A see through digital clock",
                    UnitPrice = 35.99,
                    Image = "digitalClock.jpg"
                },
                new Product
                {
                    ProductID = 5,
                    Name = "Fancy Future Chair",
                    Description = "A fancy chair from the future",
                    UnitPrice = 49.99,
                    Image = "fancyChair.jpg"
                },
                new Product
                {
                    ProductID = 6,
                    Name = "Bluetooth headphones",
                    Description = "Wireless headphones",
                    UnitPrice = 19.99,
                    Image = "headPhones.jpg"
                },
                new Product
                {
                    ProductID = 7,
                    Name = "Mini Camera",
                    Description = "A mini camera for mini picutres",
                    UnitPrice = 69.99,
                    Image = "miniCamera.jpg"
                },
                new Product
                {
                    ProductID = 8,
                    Name = "Smart Coffee Maker",
                    Description = "A smart coffee maker, make coffee from your phone",
                    UnitPrice = 74.99,
                    Image = "smartCofee.jpg"
                },
                new Product
                {
                    ProductID = 9,
                    Name = "Smart Toaster",
                    Description = "A smart toaster maker, make toast from your phone",
                    UnitPrice = 25.99,
                    Image = "smartToaster.jpg"
                },
                new Product
                {
                    ProductID = 10,
                    Name = "Watermelon Cutter",
                    Description = "Cut watermealons with ease",
                    UnitPrice = 34.99,
                    Image = "waterMelonCutter.jpg"
                }
                );
        }
    }
}
