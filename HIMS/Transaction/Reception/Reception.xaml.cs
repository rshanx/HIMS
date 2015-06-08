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

namespace HIMS.Transaction.Reception
{
    /// <summary>
    /// Interaction logic for Reception.xaml
    /// </summary>
    public partial class Reception : Window
    {
        public Reception()
        {
            InitializeComponent();
        }
        int i = 0,j=0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i == 1)
            {
                cancelgb.IsEnabled = true;
                txtCancel.Focus();
                ///tagb.IsEnabled = false;
                ///
            }
            else
            {
                cancelgb.IsEnabled = false;
                i=0;
                txtCancel.Text = "";
                btnCancel.Focus();
            }
            
        }

        private void tabtn_Click(object sender, RoutedEventArgs e)
        {
            j++;
            if(j==1)
            {
                tagb.IsEnabled = true;
                txtTel.Focus();
            }
            else
            {
                tagb.IsEnabled = false;
                j = 0;
                txtTel.Text = "";
                btnTel.Focus();
            }
            
        }
    }
}
