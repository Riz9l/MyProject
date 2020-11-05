using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.DataBase;

namespace WpfApp1.Function
{
    class Admin
    {
        SocFondEntities DB2 = new SocFondEntities();
        
        public void Load(DataGrid DGWorker,ComboBox CBPost,DataGrid DGDec)
        {
            DB2.SaveChanges();
            DGDec.ItemsSource = DB2.Declarant.ToList();
            DGWorker.ItemsSource = DB2.WorkerMfc.ToList();
            CBPost.ItemsSource = DB2.Post.Select(x => x.Post1).ToList();
        }
        public void Fill(TextBox TBLast, TextBox TBLog, TextBox TBName, TextBox TBPass, TextBox TBSur, TextBox TBTel,ComboBox cBPost,DataGrid DGWorker)
        {
            WorkerMfc worker = DGWorker.SelectedItem as WorkerMfc;
            if (worker == null)
                return;
            TBLast.Text = worker.Lastname;
            TBLog.Text = worker.Login;
            TBName.Text = worker.Firstname;
            TBPass.Text = worker.PassportWorker;
            TBSur.Text = worker.Surname;
            TBTel.Text = worker.Telephone;
            cBPost.Text = worker.PostWorker;




        }
        public void Edit(TextBox TBLast, TextBox TBLog, TextBox TBName, TextBox TBPass, TextBox TBSur, TextBox TBTel, ComboBox cBPost, DataGrid DGWorker)
        {
            WorkerMfc worker = DGWorker.SelectedItem as WorkerMfc;
            if (worker == null)
                return;
            worker.Lastname = TBLast.Text;
            worker.Firstname = TBName.Text;
            worker.PassportWorker = TBPass.Text;
            worker.Surname = TBSur.Text;
            worker.Telephone = TBTel.Text;
            worker.PostWorker = cBPost.Text;
            DB2.SaveChanges();

        }
        public void Add(TextBox TBLast, TextBox TBLog, TextBox TBName, TextBox TBPass, TextBox TBSur, TextBox TBTel, ComboBox cBPost)
        {
            WorkerMfc worker = new WorkerMfc
            {
                Lastname = TBLast.Text,
                Firstname = TBName.Text,
                Surname = TBSur.Text,
                Telephone = TBTel.Text,
                Login = TBLog.Text,
                Password = Hash.HashPassword("qwe"),
                PostWorker = cBPost.Text,
                PassportWorker = TBPass.Text
                
            };
            DB2.WorkerMfc.Add(worker);
            DB2.SaveChanges();
            
        }
        public void Dell(DataGrid DGWorker)
        {
            WorkerMfc worker = DGWorker.SelectedItem as WorkerMfc;
            if (worker == null)
                return;
            MessageBoxResult msbr = MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (msbr == MessageBoxResult.Yes)
            {
                DB2.WorkerMfc.Remove(worker);
                
            }
        }
        public void Clear(TextBox TBLast, TextBox TBLog, TextBox TBName, TextBox TBPass, TextBox TBSur, TextBox TBTel,ComboBox cBPost,DataGrid DGWorker)
        {
            TBLast.Clear();
            TBLog.Clear();
            TBName.Clear();
            TBPass.Clear();
            TBSur.Clear();
            TBTel.Clear();
            cBPost.SelectedIndex = 0;
            DGWorker.SelectedIndex = -1;
        }
        public void PassChanged(TextBox tb1,TextBox tb2,WorkerMfc f)
        {
            WorkerMfc worker = DB2.WorkerMfc.Where(c => c.Login == f.Login).SingleOrDefault();
            if(tb1.Text != tb2.Text)
            {
                MessageBox.Show("Пароли не совпадает в полях");
            }
            else if (tb2.Text == "qwe")
            {
                MessageBox.Show("Пароль не может быть -qwe ");
            }
            else if (tb1.Text.Length < 8)
            {
                MessageBox.Show("Ваш пороль меньше 8 символов");
            }
            else
            {
                worker.Password = Hash.HashPassword(tb2.Text);
                DB2.SaveChanges();
            }

        }

    }
}
