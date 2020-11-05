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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        SocFondEntities DB2 = new SocFondEntities();
       
        Function.Admin admin = new Function.Admin();
        Function.Functions functions = new Function.Functions();
        
        public Admin()
        {
            InitializeComponent();
            var bc = new BrushConverter();
            Grid1.Background = (Brush)bc.ConvertFrom("#FF181B28"); 
            Update();
            
        }
        public void Update()
        {
           
            admin.Load(DGWorker,CBPost,DGDeclarant);
            
        }

        private void DGWorker_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {  
            admin.Fill(TBLast,TBLog,TBName,TBPass,TBSur,TBTel,CBPost,DGWorker);
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        { 
            if(functions.CheckEmpty(TBPass) || functions.CheckEmpty(TBLast) || functions.CheckEmpty(TBName) || functions.CheckEmpty(TBSur) || functions.CheckEmpty(TBTel) || functions.CheckEmpty(TBLog) )
            {
                MessageBox.Show("Ошибка не все поля заполнены");
            }
            else
            {
                admin.Add(TBLast, TBLog, TBName, TBPass, TBSur, TBTel, CBPost);
                Update();
            }
           
        }

        private void BTEdit_Click(object sender, RoutedEventArgs e)
        {
            if (functions.CheckEmpty(TBPass) || functions.CheckEmpty(TBLast) || functions.CheckEmpty(TBName) || functions.CheckEmpty(TBSur) || functions.CheckEmpty(TBTel) || functions.CheckEmpty(TBLog))
            {
                MessageBox.Show("Ошибка не все поля заполнены");
            }
            else
            {
                admin.Edit(TBLast, TBLog, TBName, TBPass, TBSur, TBTel, CBPost, DGWorker);
                Update();
            }
                
        }

        private void BTDell_Click(object sender, RoutedEventArgs e)
        {
            admin.Dell(DGWorker);
            admin.Clear(TBLast, TBLog, TBName, TBPass, TBSur, TBTel, CBPost, DGWorker);
            Update();
        }

        private void BTClear_Click(object sender, RoutedEventArgs e)
        {
            admin.Clear(TBLast, TBLog, TBName, TBPass, TBSur, TBTel, CBPost,DGWorker);           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

      

        private void TBPass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void WinAdmin_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TI1.Height = (this.Height - 45) / 3;
            TI2.Height = (this.Height - 45) / 3;
            TIWorker.Height = (this.Height - 45) / 3;


        }
    }
}
