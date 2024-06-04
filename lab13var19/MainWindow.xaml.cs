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

namespace lab13var19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TrainsLab13Entities db = new TrainsLab13Entities();

        public MainWindow()
        {
            InitializeComponent();

            dgTrains.ItemsSource = db.Timesheet.ToList(); 
        }

        private void btnNow_Click(object sender, RoutedEventArgs e)
        {
            List<Timesheet> list = new List<Timesheet>();
            var time = DateTime.Now.TimeOfDay;
            var date = DateTime.Today.Date;
            foreach(var  t in db.Timesheet.ToList())
            {
                if(t.Date == date)
                {
                    var minutes = t.DepartureTime - time;
                    if (minutes <= new TimeSpan(0, 5, 0) && minutes > new TimeSpan(0, 0, 0))
                    {
                        list.Add(t);
                    }
                }
            }
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = list;
        }

        private void btnSoon_Click(object sender, RoutedEventArgs e)
        {
            List<Timesheet> list = new List<Timesheet>();
            var date = DateTime.Now;
            foreach (var t in db.Timesheet.ToList())
            {
                if (t.Date > date.Date)
                {
                    list.Add(t);
                }
                if(t.Date == date.Date)
                {
                    if (t.DepartureTime > date.TimeOfDay)
                    {
                        list.Add(t);
                    }
                }
            }
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Timesheet> list = new List<Timesheet>();
            var from = txbFrom.Text;
            var to = txbTo.Text;
            foreach (var t in db.Timesheet.ToList())
            {
                if(t.Direction.StartsWith(from) && t.Direction.EndsWith(to))
                {
                    list.Add(t) ;
                }
            }
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = list;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = db.Timesheet.ToList();
        }
    }
}
