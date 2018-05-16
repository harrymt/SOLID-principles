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
            db.Add();
        }
    }

    public class Database : IDatabase
    {
        public void Add() { }

        public void AddExistingCustomer() { }

        public void AnotherExtension() { }
    }

    public interface IDatabase
    {
        void Add();
    }

}
