using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFireBase
{
    class Program
    {
        static void Main(string[] args)
        {
           

            DAOMSSQLProvider daosql = new DAOMSSQLProvider();

            //Get All Customers
            List<Customer> list = daosql.GetAllCustomers();
            list.ForEach(c => Console.WriteLine(JsonConvert.SerializeObject(c)));

            ////Get All Orders
            //List<Order> list = daosql.GetAllOrders();
            //list.ForEach(o => Console.WriteLine(JsonConvert.SerializeObject(o)));



            ////Get All Orders By Customer ID
            //List<Order> list = daosql.GetAllOrdersByCustomerID(2);
            //list.ForEach(o => Console.WriteLine(JsonConvert.SerializeObject(o)));

            ////Get Order By ID
            //Order order = daosql.GetOrderByID(1);
            //if (order == null)
            //    Console.WriteLine("Customer not exist");
            //Console.WriteLine(JsonConvert.SerializeObject(order));

            ////Get Customer By ID
            //Customer customer = daosql.GetCustomerByID(2);
            //if (customer == null)
            //    throw new CustomerNotFoundException();
            //Console.WriteLine(JsonConvert.SerializeObject(customer));

            ////Add Customer
            //Customer customer = new Customer()
            //{
            //    Name = "John Lennon",
            //    Country = "New York",
            //    Age = 40
            //};
            //if (daosql.AddCustomer(customer) == false)
            //    Console.WriteLine("Something wrong");
            //else
            //    Console.WriteLine("Customer added");

            ////Remove Customer
            //if (daosql.RemoveCustomer(7) == false)
            //    Console.WriteLine("Something wrong");
            //else
            //    Console.WriteLine("Customer removed");


            ////Update Customer
            //Customer customer = new Customer()
            //{
            //    ID = 2,
            //    Name = "Kurt Cobain",
            //    Country = "United States",
            //    Age = 33
            //};
            //if (daosql.UpdateCustomer(customer) == false)
            //    Console.WriteLine("Something wrong");
            //else
            //    Console.WriteLine("Customer updated");

            //// Get All Order Customer
            //List<OrderCustomer> list = daosql.GetAllOrderCustomer();
            //list.ForEach(oc => Console.WriteLine(JsonConvert.SerializeObject(oc)));

            ////Add Order
            //Order order = new Order()
            //{
            //    Customer_ID = 1,
            //    Price = 586,
            //    Date = new DateTime(2019, 11, 05)
            //};
            //if (daosql.AddOrder(order) == false)
            //    Console.WriteLine("Something wrong");
            //else
            //    Console.WriteLine("Order on the way");

            //// Remove Order
            // if (daosql.RemoveOrder(3) == false)
            //    Console.WriteLine("Something wrong");
            // else
            //    Console.WriteLine("Order removed");

            //// Update Order
            //Order order = new Order()
            //{
            //    ID = 1,
            //    Customer_ID = 2,
            //    Price = 165,
            //    Date = new DateTime(2017, 04, 21)
            //};
            //if (daosql.UpdateOrder(order) == false)
            //    Console.WriteLine("Something wrong");
            //else
            //    Console.WriteLine("Order updated");






            //********************************* Fire Base AmazonStore DB: *******************************




            DAOFireBaseProvider daofb = new DAOFireBaseProvider();


            //// Add Customer
            //Customer c = new Customer()
            //{
            //    ID = 3,
            //    Name = "Iliya Tsvibel",
            //    Country = "San Ftancisco",
            //    Age = 40
            //};
            //if (daofb.AddCustomer(c) == false)
            //    Console.WriteLine("Adding customer failed");

            //// Add Order
            // Order o = new Order()
            // {
            //     ID = 3,
            //     Customer_ID = 2,
            //     Price = 407,
            //     Date = new DateTime(2016, 12, 23)
            // };
            // if (daofb.AddOrder(o) == false)
            // Console.WriteLine("Something wring");   

            //// Get All Customers
            //List<Customer> list = daofb.GetAllCustomers();
            //list.ForEach(c => Console.WriteLine(JsonConvert.SerializeObject(c)));

            //// Get All Orders
            //List<Order> list = daofb.GetAllOrders();
            //list.ForEach(o => Console.WriteLine(JsonConvert.SerializeObject(o))); 

            //// Get All Orders By Customer ID
            //List<Order> list = daofb.GetAllOrdersByCustomerID(2);
            //list.ForEach(o => Console.WriteLine(JsonConvert.SerializeObject(o)));

            //// Get Customer By ID
            //Customer customer = daofb.GetCustomerByID(2);
            //if (customer == null)
            //    Console.WriteLine("Customer not found");
            //Console.WriteLine(JsonConvert.SerializeObject(customer));

            //// Get Order By ID
            //Order order = daofb.GetOrderByID(2);
            //if (order == null)
            //    Console.WriteLine("Order not found");
            //Console.WriteLine(JsonConvert.SerializeObject(order));

            //// Remove Customer
            //if (daofb.RemoveCustomer(3) == false)
            //    Console.WriteLine("Customer can't be removed");

            //// Remove Order
            //if (daofb.RemoveOrder(2) == false)
            //    Console.WriteLine("Order can't be removed");

            //// Update Customer
            //Customer c = new Customer()
            //{
            //    ID = 1,
            //    Name = "Karl Marks",
            //    Country = "Germany",
            //    Age = 30
            //};
            //if (daofb.UpdateCustomer(c) == false)
            //    Console.WriteLine("Customer ca/t be updated");














            //// Test #11 - Update Order
            // Order o = new Order()
            // {
            //     ID = 1,
            //     Customer_ID = 1,
            //     Price = 10.5,
            //     Date = new DateTime(2018, 05, 10)
            // };
            // if (daofb.UpdateOrder(o) == false)
            //     throw new UpdateOrderFailedException();                    - > Worked!

            //// Test #12 - Get All Order Customer
            // List<OrderCustomer> list = daofb.GetAllOrderCustomer();
            // list.ForEach(oc => Console.WriteLine(JsonConvert.SerializeObject(oc)));  - > Worked!
        }
    }
}
