namespace webBuy_with_Rest_API.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using webBuy_with_Rest_API.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<webBuy_with_Rest_API.Models.webBuyEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "webBuy_with_Rest_API.Models.webBuyEntities";
        }

        protected override void Seed(webBuy_with_Rest_API.Models.webBuyEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Category
            List<Category> categories = new List<Category>()
            {
                new Category(){name="Perfume"},
                new Category(){name="Accessories"},
                new Category(){name="Gadget"},
                new Category(){name="Toy"},
            };
            if (!context.Categories.Any())
            {
                foreach (var item in categories)
                {
                    context.Categories.Add(item);
                    context.SaveChanges();
                }
            }

            //Comission
            List<Comission> comissions = new List<Comission>()
            {
                new Comission(){date="08-Mar-21 10:15:47 PM", amount=32, shopId=2},
                new Comission(){date="12-Mar-21 10:15:47 PM", amount=3.2, shopId=2},
                new Comission(){date="14-Mar-21 10:15:47 PM", amount=4, shopId=2},
            };
            if (!context.Comissions.Any())
            {
                foreach (var item in comissions)
                {
                    context.Comissions.Add(item);
                    context.SaveChanges();
                }
            }

            //Invoice
            List<Invoice> invoices = new List<Invoice>()
            {
                new Invoice(){orderId=1, productId=1, quantity=4, unitPrice=1400},
                new Invoice(){orderId=1, productId=2, quantity=3, unitPrice=450},
                new Invoice(){orderId=2, productId=7, quantity=2, unitPrice=900},
                new Invoice(){orderId=2, productId=8, quantity=10, unitPrice=200},
                new Invoice(){orderId=4, productId=1, quantity=1, unitPrice=1400},
                new Invoice(){orderId=5, productId=2, quantity=1, unitPrice=450},
                new Invoice(){orderId=7, productId=7, quantity=1, unitPrice=900},
            };
            if (!context.Invoices.Any())
            {
                foreach (var item in invoices)
                {
                    context.Invoices.Add(item);
                    context.SaveChanges();
                }
            }

            //Order
            List<Order> orders = new List<Order>()
            {
                new Order(){total=6700, paymentId=1, date="26-Apr-21 10:15:47 PM"},
                new Order(){total=3850, paymentId=1, date="27-Apr-21 10:15:47 PM"},
                new Order(){total=1450, paymentId=1, date="28-Apr-21 11:15:47 PM"},
                new Order(){total=500, paymentId=1, date="29-Apr-21 12:05:01 PM"},
                new Order(){total=950, paymentId=1, date="01-May-21 5:05:01 PM"},
            };
            if (!context.Orders.Any())
            {
                foreach (var item in orders)
                {
                    context.Orders.Add(item);
                    context.SaveChanges();
                }
            }

            //Payment
            List<Payment> payments = new List<Payment>()
            {
                new Payment(){paymentMethod="Bkash", deliveryCharge=50},
                new Payment(){paymentMethod="PayPal", deliveryCharge=50},
                new Payment(){paymentMethod="Visa", deliveryCharge=50},
                new Payment(){paymentMethod="Google Pay", deliveryCharge=50},
            };
            if (!context.Payments.Any())
            {
                foreach (var item in payments)
                {
                    context.Payments.Add(item);
                    context.SaveChanges();
                }
            }

            //Product
            List<Product> products = new List<Product>()
            {
                new Product(){name="Perfume 5b", shopId=1, unitPrice=1400, quantity=20, date="10-Mar-21 10:15:47 PM", image="1.jpg", productStatus=0, categoryId=1},
                new Product(){name="Hand Watch 1c", shopId=2, unitPrice=450, quantity=25, date="10-Mar-21 10:15:47 PM", image="2.jpg", productStatus=1, categoryId=2},
                new Product(){name="HeadPhone 1e", shopId=3, unitPrice=900, quantity=9, date="10-Mar-21 10:15:47 PM", image="3.jpg", productStatus=1, categoryId=3},
                new Product(){name="Rubics (red)", shopId=4, unitPrice=200, quantity=21, date="10-Mar-21 10:15:47 PM", image="4.jpg", productStatus=1, categoryId=4},
            };
            if (!context.Products.Any())
            {
                foreach (var item in products)
                {
                    context.Products.Add(item);
                    context.SaveChanges();
                }
            }

            //Review
            List<Review> reviews = new List<Review>()
            {
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=1, userId=1005},
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=1002},
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=3, userId=1001},
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=4, userId=1000},
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=5, userId=9999},
                new Review(){productId=2, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=9998},
                new Review(){productId=2, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=9997},
                new Review(){productId=2, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=3, userId=9996},
                new Review(){productId=2, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=4, userId=9995},
                new Review(){productId=2, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=5, userId=9994},
                new Review(){productId=3, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=3, userId=9993},
                new Review(){productId=3, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=9992},
                new Review(){productId=3, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=3, userId=9991},
                new Review(){productId=3, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=4, userId=9990},
                new Review(){productId=3, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=5, userId=9989},
                new Review(){productId=4, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=4, userId=9988},
                new Review(){productId=4, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=9987},
                new Review(){productId=4, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=3, userId=9986},
                new Review(){productId=4, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=4, userId=9985},
                new Review(){productId=4, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=5, userId=9984},
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=9983},
                new Review(){productId=1, review="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ", rating=2, userId=9982},

            };
            if (!context.Reviews.Any())
            {
                foreach (var item in reviews)
                {
                    context.Reviews.Add(item);
                    context.SaveChanges();
                }
            }

            //Shop
            List<Shop> shops = new List<Shop>()
            {
                new Shop(){name="Perfume Shop", email="perfume01@gmail.com", shopStatus=1, balance=222, setComission=20},
                new Shop(){name="Watch Shop", email="watchsh1@gmail.com", shopStatus=1, balance=33, setComission=8},
                new Shop(){name="Accessories Shop", email="accessories1@gmail.com", shopStatus=1, balance=3323, setComission=20},
                new Shop(){name="Toy Shop", email="toy1@gmail.com", shopStatus=1, balance=221, setComission=5},
            };
            if (!context.Shops.Any())
            {
                foreach (var item in shops)
                {
                    context.Shops.Add(item);
                    context.SaveChanges();
                }
            }

            //User
            List<User> users = new List<User>()
            {
                new User(){email="john@gmail.com", name="Mr. John", password="123", phone="0123456789", address="Dhaka, Bangladesh", role="admin", userStatus=1},
                new User(){email="mark@gmail.com", name="Mark", password="123", phone="0123456789", address="Dhaka, Bangladesh", role="seller", userStatus=0},
                new User(){email="stark@gmail.com", name="Mr. Stark", password="123", phone="0123456789", address="Dhaka, Bangladesh", role="customer", userStatus=0},
            };
            if (!context.Users.Any())
            {
                foreach (var item in users)
                {
                    context.Users.Add(item);
                    context.SaveChanges();
                }
            }

            //Withdraw
            List<Withdraw> withdraws = new List<Withdraw>()
            {
                new Withdraw(){userId=1003, amount=9000, shopId=null},
                new Withdraw(){userId=1004, amount=400, shopId=2},
                new Withdraw(){userId=1004, amount=40, shopId=2},
                new Withdraw(){userId=1004, amount=50, shopId=2},
            };
            if (!context.Withdraws.Any())
            {
                foreach (var item in withdraws)
                {
                    context.Withdraws.Add(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
