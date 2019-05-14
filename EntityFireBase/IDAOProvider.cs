using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFireBase
{
    interface IDAOProvider
    {
        List<Customer> GetAllCustomers();
        List<Order> GetAllOrders();
        List<Order> GetAllOrdersByCustomerID(int customerID);
        Order GetOrderByID(int orderID);
        Customer GetCustomerByID(int customerID);
        bool AddCustomer(Customer customer);
        bool RemoveCustomer(int customerID);
        bool UpdateCustomer(Customer customer);
        bool AddOrder(Order order);
        bool RemoveOrder(int orderID);
        bool UpdateOrder(Order order);
        List<OrderCustomer> GetAllOrderCustomer();
    }
}
