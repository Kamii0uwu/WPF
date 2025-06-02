using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
using System.Windows.Shapes;

namespace ТРИЗБД_4445
{
    /// <summary>
    /// Логика взаимодействия для AddInfo.xaml
    /// </summary>
    public partial class AddInfo : Window
    {
        public Guide CurrentGuide { get; set; }
        public Tour CurrentTour { get; set; }
        public Client CurrentClient { get; set; }
        public Booking CurrentBooking { get; set; }
        public Payment CurrentPayment { get; set; }
        public AddInfo(object entity)
        {
            InitializeComponent();
            var context = TravelAgency11Entities.GetContext();

            if (entity is Guide guide)
            {
                CurrentGuide = guide;
                DataContext = CurrentGuide;
                Tabs.SelectedItem = GuideTab;
                if (guide.ID != 0) DeleteBtn.Visibility = Visibility.Visible;
            }
            else if (entity is Tour tour)
            {
                CurrentTour = tour;
                DataContext = CurrentTour;
                Tabs.SelectedItem = TourTab;
                GuideCombo.ItemsSource = context.Guide.ToList();
                if (tour.ID != 0) DeleteBtn.Visibility = Visibility.Visible;
            }
            else if (entity is Client client)
            {
                CurrentClient = client;
                DataContext = CurrentClient;
                Tabs.SelectedItem = ClientTab;
                if (client.ID != 0) DeleteBtn.Visibility = Visibility.Visible;
            }
            else if (entity is Booking booking)
            {
                CurrentBooking = booking;
                DataContext = CurrentBooking;
                Tabs.SelectedItem = BookingTab;
                BookingClientCombo.ItemsSource = context.Client.ToList();
                BookingTourCombo.ItemsSource = context.Tour.ToList();
                if (booking.ID != 0) DeleteBtn.Visibility = Visibility.Visible;
            }
            else if (entity is Payment payment)
            {
                CurrentPayment = payment;
                DataContext = CurrentPayment;
                Tabs.SelectedItem = PaymentTab;
                PaymentBookingCombo.ItemsSource = context.Booking.ToList();
                if (payment.ID != 0) DeleteBtn.Visibility = Visibility.Visible;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var context = TravelAgency11Entities.GetContext();
                if (CurrentGuide != null)
                {
                    context.Guide.Remove(CurrentGuide);
                }
                else if (CurrentTour != null)
                {
                    context.Tour.Remove(CurrentTour);
                }
                else if (CurrentClient != null)
                {
                    context.Client.Remove(CurrentClient);
                }
                else if (CurrentBooking != null)
                {
                    context.Booking.Remove(CurrentBooking);
                }
                else if (CurrentPayment != null)
                {
                    context.Payment.Remove(CurrentPayment);
                }
                context.SaveChanges();
                DialogResult = true;
                Close();
            }
        }
    }
}
