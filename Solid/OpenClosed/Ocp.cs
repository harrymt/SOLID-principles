namespace Solid.OpenClosed
{
    class Ocp : IPrinciple
    {
        public string Principle()
        {
            return "Open for Extension, Closed for Modification";
        }
    }

    // Violating the Open Closed Principle
    // This is bad, because at the moment, there are 2 types
    // of customer, if we want to add another customer type
    // we have to add a `if else` below. So Modifying the existing code
    internal class Customer
    {
        public int Type;

        public virtual void Add(Database db)
        {
            if (Type == 0)
            {
                db.Add();
            }
            else
            {
                db.AddExistingCustomer();
            }
        }
    }

    // This is better, because we structure the code so its
    // easier to extend and hard to modify
    internal class CustomerBetter
    {
        public virtual void Add(Database db)
        {
            db.Add();
        }
    }

    internal class ExistingCustomer : CustomerBetter
    {
        public override void Add(Database db)
        {
            db.AddExistingCustomer();
        }
    }

    internal class AnotherCustomer : CustomerBetter
    {
        public override void Add(Database db)
        {
            db.AnotherExtension();
        }
    }
}
