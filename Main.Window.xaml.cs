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

namespace ТРИЗБД_4445
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            var context = TravelAgency11Entities.GetContext();
            GuidesGrid.ItemsSource = context.Guide.ToList();
            ToursGrid.ItemsSource = context.Tour.ToList();
            ClientsGrid.ItemsSource = context.Client.ToList();
            BookingsGrid.ItemsSource = context.Booking.ToList();
            PaymentsGrid.ItemsSource = context.Payment.ToList();
        }

        private void AddGuide_Click(object sender, RoutedEventArgs e)
        {
            AddInfo window = new AddInfo(new Guide());
            if (window.ShowDialog() == true)
            {
                var context = TravelAgency11Entities.GetContext();
                context.Guide.Add(window.CurrentGuide);
                context.SaveChanges();
                LoadData();
            }
        }

        private void EditGuide_Click(object sender, RoutedEventArgs e)
        {
            var guide = (sender as Button).DataContext as Guide;
            AddInfo window = new AddInfo(guide);
            if (window.ShowDialog() == true)
            {
                TravelAgency11Entities.GetContext().SaveChanges();
                LoadData();
            }
        }

        private void AddTour_Click(object sender, RoutedEventArgs e)
        {
            AddInfo window = new AddInfo(new Tour());
            if (window.ShowDialog() == true)
            {
                var context = TravelAgency11Entities.GetContext();
                context.Tour.Add(window.CurrentTour);
                context.SaveChanges();
                LoadData();
            }
        }

        private void EditTour_Click(object sender, RoutedEventArgs e)
        {
            var tour = (sender as Button).DataContext as Tour;
            AddInfo window = new AddInfo(tour);
            if (window.ShowDialog() == true)
            {
                TravelAgency11Entities.GetContext().SaveChanges();
                LoadData();
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddInfo window = new AddInfo(new Client());
            if (window.ShowDialog() == true)
            {
                var context = TravelAgency11Entities.GetContext();
                context.Client.Add(window.CurrentClient);
                context.SaveChanges();
                LoadData();
            }
        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            var client = (sender as Button).DataContext as Client;
            AddInfo window = new AddInfo(client);
            if (window.ShowDialog() == true)
            {
                TravelAgency11Entities.GetContext().SaveChanges();
                LoadData();
            }
        }

        private void AddBooking_Click(object sender, RoutedEventArgs e)
        {
            AddInfo window = new AddInfo(new Booking { Date = DateTime.Today });
            if (window.ShowDialog() == true)
            {
                var context = TravelAgency11Entities.GetContext();
                context.Booking.Add(window.CurrentBooking);
                context.SaveChanges();
                LoadData();
            }
        }

        private void EditBooking_Click(object sender, RoutedEventArgs e)
        {
            var booking = (sender as Button).DataContext as Booking;
            AddInfo window = new AddInfo(booking);
            if (window.ShowDialog() == true)
            {
                TravelAgency11Entities.GetContext().SaveChanges();
                LoadData();
            }
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            AddInfo window = new AddInfo(new Payment { Date = DateTime.Today });
            if (window.ShowDialog() == true)
            {
                var context = TravelAgency11Entities.GetContext();
                context.Payment.Add(window.CurrentPayment);
                context.SaveChanges();
                LoadData();
            }
        }

        private void EditPayment_Click(object sender, RoutedEventArgs e)
        {
            var payment = (sender as Button).DataContext as Payment;
            AddInfo window = new AddInfo(payment);
            if (window.ShowDialog() == true)
            {
                TravelAgency11Entities.GetContext().SaveChanges();
                LoadData();
            }
        }
    }
}
