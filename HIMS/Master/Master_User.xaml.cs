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

namespace HIMS.Master
{
    /// <summary>
    /// Interaction logic for Master_User.xaml
    /// </summary>
    public partial class Master_User : MetroWindow
    {
        public Master_User()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Master.Mater_User_Reset_Password obj = new Mater_User_Reset_Password();
            obj.Show();
        }
    }
}
