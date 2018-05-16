using System;
using System.IO;
using Solid.SingleResponsibility;

namespace Solid.DependencyInversion
{
    class Dip : IPrinciple
    {
        public string Principle()
        {
            return "Dependency Inversion";
        }

        internal class FileLogger
        {
            public void Handle(string error)
            {
                File.WriteAllText(@"C:\Error.txt", error);
            }
        }


        // Bad: We are relying on the customer to say that we 
        // are using a File Logger, rather than another type of
        // logger, e.g. EmailLogger.
        internal class Customer
        {
            FileLogger logger = new FileLogger();

            public void Add(Database db)
            {
                try
                {
                    db.Add();
                }
                catch (Exception error)
                {
                    logger.Handle(error.ToString());
                }
            }
        }


        // Good: We pass in a Logger interface to the customer
        // so it doesnt know what type of logger it is
        class BetterCustomer
        {
            private ILogger logger;
            public BetterCustomer(ILogger logger)
            {
                this.logger = logger;
            }

            public void Add(Database db)
            {
                try
                {
                    db.Add();
                }
                catch (Exception error)
                {
                    logger.Handle(error.ToString());
                }
            }
        }
        class EmailLogger : ILogger
        {
            public void Handle(string error)
            {
                File.WriteAllText(@"C:\Error.txt", error);
            }
        }

        interface ILogger
        {
            void Handle(string error);
        }

        // e.g. when it is used:
        void UseDependencyInjectionForLogger()
        {
            var customer = new BetterCustomer(new EmailLogger());
            customer.Add(new Database());
        }
    }
}
