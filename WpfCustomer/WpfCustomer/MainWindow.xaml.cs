using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ServiceModel;
using System.Threading;
using System.Collections.ObjectModel;

namespace WpfCustomer
{
    [CallbackBehavior(UseSynchronizationContext =true)]
    public partial class MainWindow : Window, OrderService.IOrderPlacementServiceCallback
    {

        ObservableCollection<Order> orders;


        InstanceContext instanceContext;
       OrderService.OrderPlacementServiceClient client;
        public MainWindow() 
        {
            InitializeComponent();
            instanceContext = new InstanceContext(this);

            orders = new ObservableCollection<Order>();
            client = new OrderService.OrderPlacementServiceClient(instanceContext);
            client.OrderSubscribe();
        }
      

        public void OrderCallback(int Id, string Name, DateTime dateTime)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                ProcessingLabel.Content = "CB from KS to Cust ID:" + Id + Name+dateTime;
            }));
        }

        int burgerId = 1;
        public void burger()
        {

            //while (true)
            //{
                string burgerName = "Burger";
                client.PlaceOrder(burgerId, burgerName, DateTime.Now);
                burgerId++;
              //  Thread.Sleep(1000);

            //}
        }

        int pizzaId = 1;
        public void pizza()
        {
            //while (true)
            //{
                //string pizzaName = "Pizza";
                //client.PlaceOrder(pizzaId, pizzaName, DateTime.Now);
                //pizzaId++;
               // Thread.Sleep(2000);

            //}
        }

        int chipsId = 1;
        public void chips()
        {
            //while (true)
            //{
                //string chipsName = "Chips";
                //client.PlaceOrder(chipsId, chipsName, DateTime.Now);
                //chipsId++;
               //Thread.Sleep(3000);
            //}
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

//             for (int i = 0; i < 10; i++)
//            {
                Thread t1 = new Thread(burger);
                Thread t2 = new Thread(pizza);
                Thread t3 = new Thread(chips);
                t1.Start();
                t2.Start();
                t3.Start();
//            }


        }

        public void SubscribeToCustomerCallback(int Id, string Name, DateTime dateTime)
        {
            Console.WriteLine(Id + " " + Name + " " + dateTime);

            this.Dispatcher.Invoke(new Action(() =>
            {
                orders.Add(new Order { Id = Id, Name = Name, Date = dateTime });
                
                dg.ItemsSource = orders;
            }));
        }


        public void PublishToOrderServiceCallback(int Id, string Name, DateTime dateTime)
        {
            //throw new NotImplementedException();
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

