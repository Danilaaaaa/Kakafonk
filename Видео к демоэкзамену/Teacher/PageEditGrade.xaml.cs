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
using Видео_к_демоэкзамену.DataFilesApp;

namespace Видео_к_демоэкзамену.Teacher
{
    /// <summary>
    /// Логика взаимодействия для PageEditGrade.xaml
    /// </summary>
    public partial class PageEditGrade : Page
    {
        public PageEditGrade()
        {
            InitializeComponent();
            CmbSelectGroup.DisplayMemberPath = "Name";
            CmbSelectGroup.SelectedValuePath = "ID";
            CmbSelectGroup.ItemsSource = odbconnecthelper.entObj.NameGroup.ToList();
        }
        /// <summary>
        /// Edit Grade Student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditGrade_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageEditGradeStudent((sender as Button ).DataContext as Student));
        }
        /// <summary>
        /// Логика Фильтра данных по группам студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSelectGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(CmbSelectGroup.SelectedValue);
            ListStudent.ItemsSource = odbconnecthelper.entObj.Student.Where(x => x.IDNameGroup == SelectGroup ).ToList();
            ListStudent.SelectedIndex = 0;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
