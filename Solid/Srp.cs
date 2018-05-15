using System;
using System.IO;

namespace Solid
{
    class Srp : IPrinciple
    {
        public string Principle()
        {
            return "Single Responsibility Principle";
        }
    }

    // Violating the Single Responsibility Principle
    class CustomerBad
    {
        public void Add(Database db)
        {
            try
            {
                db.AddNewCustomer();
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Error.txt", ex.ToString());
            }
        }
    }




    // Good Way, not violating the single responsibility principle
    class GoodCustomer
    {
        private FileLogger logger = new FileLogger();
        public void Add(Database db)
        {
            try {
                db.AddNewCustomer();
            }
            catch (Exception ex)
            {
                logger.Handle(ex.ToString());
            }
        }
    }
    class FileLogger
    {
        public void Handle(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }



    // Even Better Way
    class Wrapper
    {
        public void HandleAdd(FileLogger logger, Database db, Customer customer)
        {
            try
            {
                customer.Add(db);
            }
            catch (Exception error)
            {
                logger.Handle(error.ToString());
            }
        }
    }

    class Customer
    {
        public void Add(Database db)
        {
            db.AddNewCustomer();
        }
    }
}
