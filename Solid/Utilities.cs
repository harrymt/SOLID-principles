using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class Customer
    {
        public int BaseDiscount = 10;

        public virtual int Discount(int sales)
        {
            return BaseDiscount - sales;
        }

        public virtual void Add(Database db)
        {
            db.AddNewCustomer();
        }
    }

    public class Database
    {
        public void AddNewCustomer() { }

        public void AddExistingCustomer() { }

        public void AnotherExtension() { }
    }
}
