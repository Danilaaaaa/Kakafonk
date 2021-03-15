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
using Видео_к_демоэкзамену.MVC.Controller;
using Видео_к_демоэкзамену.MVC.HelpController;

namespace Видео_к_демоэкзамену.MVC
{
    /// <summary>
    /// Логика взаимодействия для PageMVC.xaml
    /// </summary>
    public partial class PageMVC : Page
    {
        public PageMVC()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ControllerLogin.CheckLoginOdb(TxbLogin.Text));
        }
    }
}
