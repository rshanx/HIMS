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
using MahApps.Metro.Controls;
using System.Windows.Navigation;

namespace HIMS.Transaction
{
    /// <summary>
    /// Interaction logic for Transaction_Home.xaml
    /// </summary>
    public partial class Transaction_Home : MetroWindow
    {
        public Transaction_Home()
        {
            InitializeComponent();
        }

        private void Reception_Click(object sender, RoutedEventArgs e)
        {
            Transaction.Reception.Reception obj = new Transaction.Reception.Reception();
            this.Hide();
            obj.Show();
        }

        private void Reception_Copy_Click(object sender, RoutedEventArgs e)
        {
            Patient_Registration obj = new Patient_Registration();
            this.Hide();
            obj.Show();
        }

        private void Reception_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Transaction.OPD.OPD obj = new Transaction.OPD.OPD();
            this.Hide();
            obj.Show();
        }

        private void Reception_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Transaction.Reception.Window_SQL_DEMO obj = new Reception.Window_SQL_DEMO();
            this.Hide();
            obj.Show();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            //Dashboard ob = new Dashboard();
            //this.Hide();
            //ob.Show();
        }

        private void Reception_Copy4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
