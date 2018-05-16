namespace Solid.InterfaceSegregation
{
    class Isp : IPrinciple
    {
        public string Principle()
        {
            return "Interface Segregation";
        }

        // If we want to add more functionality, don't add to existing
        // interfaces, segregate them out.
        interface ICustomer // existing
        {
            void Add();
        }
        // BAD:
        interface ICustomerImproved
        {
            void Add();
            void Read(); // Existing Functionality, BAD
        }

        // GOOD:
        // Just create another interface, that a class can ALSO extend from
        interface ICustomerV1 : ICustomer
        {
            void Read();
        }

        class CustomerWithRead : ICustomer, ICustomerV1
        {
            public void Add()
            {
                var customer = new Customer();
                customer.Add(new Database());
            }

            public void Read()
            {
                // GOOD: New functionality here!
            }
        }

        // e.g.
        void ManipulateCustomers()
        {
            var database = new Database();
            var customer = new Customer();
            customer.Add(database); // Old functionality, works fine
            var readCustomer = new CustomerWithRead();
            readCustomer.Read(); // Good! New functionalty is separate from existing customers
        }
    }
}
