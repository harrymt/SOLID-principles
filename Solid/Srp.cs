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
    class CustomerBadSRP
    {
        // This Add method does too much,
        // it shouldnt know how to write to the log and add a customer
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
    // Now we abstract the logger, so its just writing the error.
    class CustomerBetterSRP
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
    // Even better, the customer only knows how to add, and we
    // wrap the add method in an error handler.
    class Wrapper
    {
        public void HandleAdd(FileLogger logger, Database db, CustomerBestSRP customer)
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

    class CustomerBestSRP
    {
        public void Add(Database db)
        {
            db.AddNewCustomer();
        }
    }
}
