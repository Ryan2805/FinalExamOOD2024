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

/*Name: Ryan Daly 
 * Student Number: S00237889
 * May Exam Object Oriented Programming
 * Link to GitHub Repo : https://github.com/Ryan2805/FinalExamOOD2024   ,    https://github.com/Ryan2805/OODMayExam
 * created 2 github repos by accident, you are added as a collaborator on both. 
 * 
 * 
*/
namespace FinalExamOOD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void LoadBookings()
        {
            try
            {
                var customers = db.Customers.ToList();
                listBoxCustomers.ItemsSource = "Customers";
                listBoxCustomers.DisplayMemberPath = "Customers";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Displaying Bookings: " + ex.Message);
            }
        }

    }
}
