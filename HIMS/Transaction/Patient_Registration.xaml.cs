using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace HIMS
{
    /// <summary>
    /// Interaction logic for Patient_Registration.xaml
    /// </summary>
    public partial class Patient_Registration : MetroWindow
    {
        public Patient_Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Transaction.Transaction_Home obj = new Transaction.Transaction_Home();
            //obj.Show();
        }
    }
}
