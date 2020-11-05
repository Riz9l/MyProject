using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1.DataBase;

namespace WpfApp1.Function
{
    class Functions
    {
        SocFondEntities DB1 = new SocFondEntities();
        
        public  bool Proverka(TextBox TBlog, PasswordBox PBPass)
        {

            if (CheckEmpty(TBlog) && CheckEmpty1(PBPass))
            {
                MessageBox.Show("Ошибка! Поля пусты!!!");
                return false;
            }
            else if (String.IsNullOrEmpty(TBlog.Text))
            {
                MessageBox.Show("Ошибка! Поле логина пустое!!!");
                return false;
            }
            else if (String.IsNullOrEmpty(PBPass.Password))
            {
                MessageBox.Show("Ошибка! Поле пароля пустое!!!");
                return false;
            }
            
            
            WorkerMfc m = DB1.WorkerMfc.Where(c => c.Login == TBlog.Text).SingleOrDefault();
            if (m == null)
            {
                MessageBox.Show("Пользователя с таким логином не существует!");
                PBPass.Clear();
                return false;
            }
            else
            {
                if (Hash.VerifyHashedPassword(m.Password, PBPass.Password))
                {
                    if (Hash.VerifyHashedPassword(Hash.HashPassword("qwe"), PBPass.Password))
                    {
                        MessageBoxResult msbr = MessageBox.Show("Хотите сменить пароль?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (msbr == MessageBoxResult.Yes)
                        {
                            Windows.PassChange passChange = new Windows.PassChange(m);
                            passChange.ShowDialog();
                            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                        }
                        else
                        {
                            Application.Current.Shutdown();
                        }
                        return false;
                    }
                    else if (m.PostWorker == "Сотрудник ")
                    {
                        Windows.Main main = new Windows.Main();
                        main.Show();
                        return true;
                    }
                    else if (m.PostWorker == "Админ")
                    {
                        Windows.Admin admin = new Windows.Admin();
                        admin.Show();
                        return true;
                    }
                    else
                    {

                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Пароль неверный!");
                    PBPass.Clear();
                    return false;
                }
            }
           

    



        }
        public bool CheckEmpty(TextBox tb)
        {
            if (String.IsNullOrEmpty(tb.Text))
            {
                tb.BorderBrush = Brushes.Red;
                return true;
            }
            else
            {
                tb.BorderBrush = Brushes.Gray;
                return false;
            }


        }
        public bool CheckEmpty1(PasswordBox tb1)
        {
            if (String.IsNullOrEmpty(tb1.Password))
            {
                tb1.BorderBrush = Brushes.Red;
                return true;
            }
            else
            {
                tb1.BorderBrush = Brushes.Gray;
                return false;
            }

        }
    }
}
