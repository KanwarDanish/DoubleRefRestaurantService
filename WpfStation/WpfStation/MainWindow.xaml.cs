using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfStation.KitchenService;

namespace WpfStation
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainWindow : Window, KitchenService.IKitchenRecievingServiceCallback
    {

        ObservableCollection<Order> orders;
        KitchenService.KitchenRecievingServiceClient client;

        InstanceContext instanceContext;

        public MainWindow()
        {
            InitializeComponent();

            orders = new ObservableCollection<Order>();
            instanceContext = new InstanceContext(this);
            client = new KitchenService.KitchenRecievingServiceClient(instanceContext);

            client.KitchenSubscribe();
        }

     
        public void KitchenCallback(int orderId, string orderName, DateTime dateTime)
        {
            //throw new NotImplementedException();
        }

        public void KitchenSendToStationCallback(int orderId, string orderName, DateTime dateTime)
        {
            Console.WriteLine(orderId + " " + orderName + " " + dateTime);

            this.Dispatcher.Invoke(new Action(() =>
            {
                orders.Add(new Order { Id = orderId, Name = orderName, Date = dateTime });
                dg.ItemsSource = orders;
            }));



            Thread.Sleep(3000); //Shows processing
            client.GetBackOrder(orderId, orderName, dateTime);
        }

        public void StationSendToKitchenCallback(int orderId, string orderName, DateTime dateTime)
        {
            Console.WriteLine("This is station sending to KS {0}",orderId+orderName+dateTime);

            Order order = new Order();
            order.Id = orderId;
            order.Name = orderName;
            order.Date = dateTime;
            Console.WriteLine(order.Id + order.Name + order.Date.ToString());   
        }

        public class Order
        {
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private DateTime date;
            public DateTime Date
            {
                get { return date; }
                set { date = value; }
            }
        }

    }
}
