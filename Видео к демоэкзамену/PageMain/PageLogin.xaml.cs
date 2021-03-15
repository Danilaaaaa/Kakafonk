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
using Видео_к_демоэкзамену.ClassHelper;
using Видео_к_демоэкзамену.DataFilesApp;
using Видео_к_демоэкзамену.Director;

namespace Видео_к_демоэкзамену.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();

            if (Properties.Settings.Default.EventSaveLogin != string.Empty)
            {
                TxbLogin.Text = Properties.Settings.Default.EventSaveLogin;
            }
        }

        public void RememberMe()
        {
            if(ChkSaveLogin.IsChecked == true)
            {
                Properties.Settings.Default.EventSaveLogin = TxbLogin.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.EventSaveLogin = "";
                Properties.Settings.Default.Save();
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageRegistration());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = odbconnecthelper.entObj.User.FirstOrDefault(
                    x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password
                    );
                
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new PageRegistration());
                }

                else
                {
                    UserControlHelp.IDUser = userObj.ID;
                    UserControlHelp.NameUser = userObj.Name;

                    switch(userObj.IdRole)
                    {
                        case 1:
                            //MessageBox.Show("Здравствуйте, "+ userObj.Login +"!",
                            //"Уведомление",
                            //MessageBoxButton.OK,
                            //MessageBoxImage.Information);
                            RememberMe();
                            UserControlHelp.LoginUser = TxbLogin.Text;
                            FrameApp.frmObj.Navigate(new PageStudent());
                            break;
                        case 2:
                            //MessageBox.Show("Здравствуйте, "+ userObj.Login +"!",
                            //"Уведомление",
                            //MessageBoxButton.OK,
                            //MessageBoxImage.Information);
                            RememberMe();
                            FrameApp.frmObj.Navigate(new PageTeacher());
                            break;
                        case 3:
                            WindowDirector windowDirector = new WindowDirector();
                            windowDirector.Show();
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Критический сбой в работе приложения: " + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }
    }
}
