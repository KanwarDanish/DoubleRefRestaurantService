using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfOrderService
{
    public class OrderStart // Has defination of order characteristics
    {
        private int orderID;
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private string orderName;
        public string OrderName
        {
            get { return orderName; }
            set { orderName = value; }
        }
    }
}
