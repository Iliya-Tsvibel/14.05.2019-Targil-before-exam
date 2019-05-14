using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFireBase
{
    class DAOMSSQLProvider : IDAOProvider
    {
        


        public List<Customer> GetAllCustomers()
        {
            using (AmazonStoreEntities store = new AmazonStoreEntities())
            {
                return store.Customers.ToList();
            }
        }

        public List<OrderCustomer> GetAllOrderCustomer()
        {
            using (AmazonStoreEntities store = new AmazonStoreEntities())
            {
                return store.Orders.Join(store.Customers,
                    o => o.Customer_ID,
                    c => c.ID,
                    (o, c) => new OrderCustomer()
                    {
                        ID = o.ID,
                        CustomerID = c.ID,
                        Price = o.Price,
                        Date = o.Date,
                        CustomerName = c.Name

                    }).ToList();
            }
        }

          

        public List<Order> GetAllOrders()
        {
            using (AmazonStoreEntities store = new AmazonStoreEntities())
            {
                return store.Orders.ToList();
            }
        }

        public List<Order> GetAllOrdersByCustomerID(int customerID)
        {
            if (GetCustomerByID(customerID) == null)
                Console.WriteLine("ID dousn't exist");

            using (AmazonStoreEntities store = new AmazonStoreEntities())
            {
                return (from o in store.Orders.ToList()
                        where o.Customer_ID == customerID
                        select o).ToList();
            }
        }

        public Customer GetCustomerByID(int customerID)
        {
            

            using (AmazonStoreEntities store = new AmazonStoreEntities())
            {
                return store.Customers.ToList().Find(c => c.ID == customerID) as Customer;
            }
        }

        public Order GetOrderByID(int orderID)
        {
            

            using (AmazonStoreEntities store = new AmazonStoreEntities())
            {
                return store.Orders.ToList().Find(o => o.ID == orderID) as Order;
            }
        }


        public bool AddCustomer(Customer customer)
        {
            try
            {
                using (AmazonStoreEntities store = new AmazonStoreEntities())
                {
                    store.Customers.Add(customer);
                    store.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveCustomer(int customerID)
        {
            if (GetCustomerByID(customerID) == null)
                Console.WriteLine("Customer not found");

            try
            {
                using (AmazonStoreEntities store = new AmazonStoreEntities())
                {
                    Customer cust = store.Customers.ToList().Find(c => c.ID == customerID) as Customer;
                    store.Customers.Remove(cust);
                    store.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (GetCustomerByID(customer.ID) == null)
                Console.WriteLine("Customer not found");

            try
            {
                using (AmazonStoreEntities store = new AmazonStoreEntities())
                {
                    store.Customers.ToList().Take(1).FirstOrDefault(c => c.ID == customer.ID).Name = customer.Name;
                    store.Customers.ToList().Take(1).FirstOrDefault(c => c.ID == customer.ID).Country = customer.Country;
                    store.Customers.ToList().Take(1).FirstOrDefault(c => c.ID == customer.ID).Age = customer.Age;
                    store.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddOrder(Order order)
        {
            try
            {
                using (AmazonStoreEntities store = new AmazonStoreEntities())
                {
                    store.Orders.Add(order);
                    store.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveOrder(int orderID)
        {
            if (GetOrderByID(orderID) == null)
                Console.WriteLine("Order not found");

            try
            {
                using (AmazonStoreEntities store = new AmazonStoreEntities())
                {
                    Order order = store.Orders.ToList().Find(o => o.ID == orderID) as Order;
                    store.Orders.Remove(order);
                    store.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

      

        public bool UpdateOrder(Order order)
        {
            if (GetOrderByID(order.ID) == null)
                Console.WriteLine("Order not found");

            try
            {
                using (AmazonStoreEntities store = new AmazonStoreEntities())
                {
                    store.Orders.ToList().Find(o => o.ID == order.ID).Customer_ID = order.Customer_ID;
                    store.Orders.ToList().Find(o => o.ID == order.ID).Price = order.Price;
                    store.Orders.ToList().Find(o => o.ID == order.ID).Date = order.Date;
           
                    store.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
    
}
