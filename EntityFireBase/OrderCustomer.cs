using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFireBase
{
    public class OrderCustomer
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }

        public OrderCustomer(int customerID, decimal price, DateTime date, string customerName)
        {
            CustomerID = customerID;
            Price = price;
            Date = date;
            CustomerName = customerName;
        }

        public OrderCustomer()
        {
        }
    }
}