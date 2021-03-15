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
using System.Windows.Threading;
using Видео_к_демоэкзамену.ClassHelper;
using Видео_к_демоэкзамену.DataFilesApp;

namespace Видео_к_демоэкзамену.Director
{
    /// <summary>
    /// Логика взаимодействия для WindowDirector.xaml
    /// </summary>
    public partial class WindowDirector : Window
    {
        bool logicData = false;
        public WindowDirector()
        {
            InitializeComponent();

            TxtName.Text = UserControlHelp.NameUser;
            odbconnecthelper.entObj = new ТренировкаДэмоэкзаменаEntities();

            GridListHistory.Columns[3].CanUserSort = false;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += IzmenenieDannih;
            timer.Start();
        }

        private void IzmenenieDannih(object sender, object e)
        {
            var historyEvent = odbconnecthelper.entObj.History.ToList();
            GridListHistory.ItemsSource = historyEvent;
            TxtTotal.Text = Convert.ToString(historyEvent.Count);

            var dateResolve = historyEvent.OrderByDescending(x => x.DateEvent).FirstOrDefault();
            TxtDate.Text = dateResolve.DateEvent.ToString();
        }

        private void RbDes_Click(object sender, RoutedEventArgs e)
        {
            if (RbDes.IsChecked == true)
            {
                RbUp.IsChecked = false;
                GridListHistory.ItemsSource = odbconnecthelper.entObj.History.OrderByDescending(x => x.DateEvent).ToList();
            }
                
        }

        private void RbUp_Click(object sender, RoutedEventArgs e)
        {
            if (RbUp.IsChecked == true)
            {
                RbDes.IsChecked = false;
                GridListHistory.ItemsSource = odbconnecthelper.entObj.History.OrderBy(x => x.DateEvent).ToList();
            }
        }

        bool size = false;

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnUpDownResize_Click(object sender, RoutedEventArgs e)
        {
            if(size == false)
            {
                this.WindowState = WindowState.Maximized;
                size = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                size = false;
            }
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
