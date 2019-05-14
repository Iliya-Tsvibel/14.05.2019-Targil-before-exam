using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFireBase
{
    class DAOFireBaseProvider : IDAOProvider
    {
        private static IFirebaseConfig config;
        private static IFirebaseClient firebaseClient;

        public DAOFireBaseProvider()
        {
            config = new FirebaseConfig();
            firebaseClient = new FirebaseClient(config);

            config.AuthSecret = ConfigurationManager.AppSettings["AmazonFireBaseKey"];
            config.BasePath = ConfigurationManager.AppSettings["AmazonFireBaseURL"];

            firebaseClient = new FireSharp.FirebaseClient(config);
            if (firebaseClient != null)
            {
                Console.WriteLine("Connection Succeeded!");
            }
        }

        public bool AddCustomer(Customer customer)
        {
            SetResponse response = firebaseClient.Set($"Customers/Cust{customer.ID}/", customer);
            Customer result = response.ResultAs<Customer>();

            Console.WriteLine("Customer added successfully " + customer.ID);

            if (result != null)
                return false;
            else
                return true;
        }

        public bool AddOrder(Order order)
        {

            if (GetOrderByID(order.ID) != null)
                Console.WriteLine("This order already exist");

            else if (GetCustomerByID(order.Customer_ID) == null)
                Console.WriteLine("Customer not found");

            SetResponse response = firebaseClient.Set($"Orders/Ord{order.ID}/", order);
            Order result = response.ResultAs<Order>();

            Console.WriteLine("Order added successfully " + order.ID);

            if (result != null)
                return false;
            else
                return true;

            

        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            int i = 1;

            while (true)
            {
                FirebaseResponse response = firebaseClient.Get($"Customers/Cust{i}/");

                Customer customer = response.ResultAs<Customer>();

                if (customer == null)
                    break;
            
                result.Add(response.ResultAs<Customer>());
                i++;
            }
            
            return result;
        }

        public List<OrderCustomer> GetAllOrderCustomer()
        {
            List<OrderCustomer> result = new List<OrderCustomer>();
            int i = 1;

            while(true)
            {
                FirebaseResponse response = firebaseClient.Get($"Orders/Ord{i}/");

                Order order = response.ResultAs<Order>();

                if (order == null)
                    break;

                OrderCustomer oc = new OrderCustomer
                {
                    ID = order.ID,
                    CustomerID = order.Customer_ID,
                    Price = order.Price,
                    Date = order.Date,
                    CustomerName = GetCustomerByID(order.Customer_ID).Name
                };

                result.Add(oc);

                i++;
            }

            return result;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> result = new List<Order>();
            int i = 1;

            while (true)
            {
                FirebaseResponse response = firebaseClient.Get($"Orders/Ord{i}/");

                Order order = response.ResultAs<Order>();

                if (order == null)
                    break;

                result.Add(response.ResultAs<Order>());
                i++;
            }

            return result;
        }

        public List<Order> GetAllOrdersByCustomerID(int customerID)
        {
            List<Order> result = new List<Order>();
            int i = 0;

            while (true)
            {
                i++; 

                FirebaseResponse response = firebaseClient.Get($"Orders/Ord{i}/");

                Order order = response.ResultAs<Order>();

                if (order == null)
                    break;
                else if (order.Customer_ID != customerID)
                    continue;

                result.Add(response.ResultAs<Order>());
            }

            return result;
        }

        public Customer GetCustomerByID(int customerID)
        {
            FirebaseResponse response = firebaseClient.Get($"Customers/Cust{customerID}/");
            Customer result = response.ResultAs<Customer>();

            return result; 
        }

        public Order GetOrderByID(int orderID)
        {
            FirebaseResponse response = firebaseClient.Get($"Orders/Ord{orderID}/");
            Order result = response.ResultAs<Order>();

            return result;
        }

        public bool RemoveCustomer(int customerID)
        {
            if (GetCustomerByID(customerID) == null)
                Console.WriteLine("Customer not exist");

            if (GetAllOrdersByCustomerID(customerID) != null)
                Console.WriteLine("Customer can't be removed");

              FirebaseResponse response = firebaseClient.Delete($"Customers/Cust{customerID}");
              Customer result = response.ResultAs<Customer>();


            if (result != null)
                return false;
            else
                return true;

        }

        public bool RemoveOrder(int orderID)
        {
            if (GetOrderByID(orderID) == null)
                Console.WriteLine("Order can't be removed");

            
                FirebaseResponse response = firebaseClient.Delete($"Orders/Ord{orderID}");
                return true;
            
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (GetCustomerByID(customer.ID) == null)
                Console.WriteLine("Customer not found");

               FirebaseResponse response = firebaseClient.Update($"Customers/Cust{customer.ID}", customer);
                return true;
          
        }

        public bool UpdateOrder(Order order)
        {
            if (GetOrderByID(order.ID) == null)
                Console.WriteLine("Order not found");

            if (GetCustomerByID(order.Customer_ID) == null)
                Console.WriteLine("Customer not found");

            
                FirebaseResponse response = firebaseClient.Update($"Orders/Ord{order.ID}", order);
                return true;
          
        }

    }
}
