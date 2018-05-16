using System;

namespace Solid.Liskov
{
    class Lsp : IPrinciple
    {
        public string Principle()
        {
            return "Liskov Substitution Principle";
        }

        // You should be able to subclass from a class and not break any functionality
        // e.g. here, we don't want this to add an enquiry so we have to throw
        // a new exception, that is violating the principle
        class Enquiry : Customer
        {
            public override int Discount(int sales)
            {
                return this.BaseDiscount - 5;
            }

            public override void Add(Database db)
            {
                throw new Exception("Not allowed");
            }
        }
    }
}
