using HIMS.MSTR;
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

namespace HIMS.Master
{
    /// <summary>
    /// Interaction logic for Master_Dashboard.xaml
    /// </summary>
    public partial class Master_Dashboard : MetroWindow
    {
        public Master_Dashboard()
        {
            InitializeComponent();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            this.Hide();
            //ob.Show();
        }

        private void Reception_Click(object sender, RoutedEventArgs e)
        {
            MSTR.Master_Medicine obj = new MSTR.Master_Medicine();
            //this.Hide();
            obj.Show();
        }

        private void Reception_Copy_Click(object sender, RoutedEventArgs e)
        {
            MSTR.Master_Diagnosis obj = new Master_Diagnosis();
            obj.Show();
        }

        private void Reception_Copy1_Click(object sender, RoutedEventArgs e)
        {
            MSTR.Master_DrugGroup OBJ = new Master_DrugGroup();
            OBJ.Show();
        }

        private void Reception_Copy2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reception_Copy4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reception_Copy5_Click(object sender, RoutedEventArgs e)
        {
            Master_User OBJ = new Master_User();
            OBJ.Show();
        }
    }
}
