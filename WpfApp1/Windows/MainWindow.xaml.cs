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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Function.Functions fun = new Function.Functions();
        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void BTAutore_Click(object sender, RoutedEventArgs e)
        {

         
           
            if (fun.Proverka(TBLog, PBPassword) == true)
            {
                

                    this.Close();
      
            }
        }

        private void BTClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

   
    }
}
