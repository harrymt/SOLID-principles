using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    class Srp : IPrinciple
    {
        public string Principle()
        {
            return "Single Responsibility Principle";
        }
    }

    // Good Way, not violating the single responsibility principle
    class Customer
    {
        var logger = new FileLogger();
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
        void Handle(string error)
        {
            File.WriteAllText(@"C:\Error.txt", ex.ToString());
        }
    }

    // Violating the Single Responsibility Principle
    class CustomerBad
    {
        public void Add(Database db)
        {
            try {
                db.AddNewCustomer();
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Error.txt", ex.ToString());
            }
        }
    }
}
