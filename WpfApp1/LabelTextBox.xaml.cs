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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для LabelTextBox.xaml
    /// </summary>
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox(string Content, string Text)
        {
            InitializeComponent();
            lb.Content = Content;
            tb.Text = Text;
        }
        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb.Text != null)
            {
                tb.Background = Brushes.White;
            }


        }

    }
}
