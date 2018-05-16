using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    class Ocp : IPrinciple
    {
        public string Principle()
        {
            return "Open for Extension, Closed for Modification.";
        }
    }

    // Violating the Open Closed Principle
    // This is bad, because at the moment, there are 2 types
    // of customer, if we want to add another customer type
    // we have to add a `if else` below. So Modifying the existing code
    class CustomerBadOCP
    {
        public int Type;

        public void Add(Database db)
        {
            if (Type == 0)
            {
                db.AddNewCustomer();
            }
            else
            {
                db.AddExistingCustomer();
            }
        }
    }

    // This is better, because we structure the code so its
    // easier to extend and hard to modify
    class CustomerOCP
    {
        public virtual void Add(Database db)
        {
            db.AddNewCustomer();
        }
    }

    class ExistingCustomerOCP : CustomerOCP
    {
        public override void Add(Database db)
        {
            db.AddExistingCustomer();
        }
    }

    class AnotherCustomerTypeOCP : CustomerOCP
    {
        public override void Add(Database db)
        {
            db.AnotherExtension();
        }
    }
}
