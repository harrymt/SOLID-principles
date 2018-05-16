using System;
using System.Collections.Generic;
using Solid.OpenClosed;

namespace Solid.Liskov
{
    class Lsp : IPrinciple
    {
        public string Principle()
        {
            return "Liskov Substitution";
        }

        // BAD: Violating Liskov substitution principle
        // The parent should easily the replace the child object and not break any functionality, only lose some.
        // e.g. here, we don't want this to add an enquiry so we have to throw
        // a new exception, that is violating the principle
        class Enquiry : Customer
        {
            public override int Discount(int sales)
            {
                return this.BaseDiscount - (sales * 5);
            }

            public override void Add(Database db)
            {
                throw new Exception("Not allowed");
            }
        }
        // e.g. to show how this is bad:
        public class GoldCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - sales - 100;
            }
        }

        public class SilverCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - sales - 50;
            }
        }

        class ViolatingLiskovs
        {
            public void ParseCustomers()
            {
                var database = new Database();
                var customers = new List<Customer>
                {
                    new GoldCustomer(), 
                    new SilverCustomer(), 
                    new Enquiry() // This is valid
                };

                foreach (Customer c in customers)
                {
                    // Enquiry.Add() will throw an exception here!
                    c.Add(database);
                }
            }
        }

        // Better method:
        interface IDiscount
        {
            int Discount(int sales);
        }

        interface IDatabase
        {
            void Add(Database db);
        }

        internal class BetterCustomer : IDiscount, IDatabase
        {
            public virtual int Discount(int sales)
            {
                return sales;
            }

            public void Add(Database db)
            {
                db.Add();
            }
        }

        internal class BetterGoldCustomer : BetterCustomer
        {
            public override int Discount(int sales)
            {
                return sales - 100;
            }
        }

        internal class BetterSilverCustomer : BetterCustomer
        {
            public override int Discount(int sales)
            {
                return sales - 50;
            }
        }

        // GOOD: Now, we don't violate Liskov Substitution principle
        class AdheringToLiskovs
        {
            public void ParseCustomers()
            {
                var database = new Database();
                var customers = new List<BetterCustomer>
                {
                    new BetterGoldCustomer(),
                    new BetterSilverCustomer(),
                    // new Enquiry() // This will give a compiler error, rather than runtime error
                };

                foreach (BetterCustomer c in customers)
                {
                    // Enquiry.Add() will throw an exception here!
                    c.Add(database);
                }
            }
        }

    }

}
