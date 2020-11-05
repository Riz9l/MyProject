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
using WpfApp1.DataBase;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для PassChange.xaml
    /// </summary>
    public partial class PassChange : Window
    {
        private readonly WorkerMfc m;
        SocFondEntities SocFondEntities = new SocFondEntities();
        Function.Admin admin = new Function.Admin();
        public PassChange(WorkerMfc m) 
        {
            InitializeComponent();
            this.m = m;
        }
        

        private void BTPassChan_Click(object sender, RoutedEventArgs e)
        {
            
           
            
                admin.PassChanged(TBNewPass, TBNewPassRep, m);
                this.Close();
            
            
          
        }
    }
}
