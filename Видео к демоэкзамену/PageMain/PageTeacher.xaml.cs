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
using Видео_к_демоэкзамену.MVC;
using Видео_к_демоэкзамену.Teacher;

namespace Видео_к_демоэкзамену.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageTeacher.xaml
    /// </summary>
    public partial class PageTeacher : Page
    {
        public PageTeacher()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddStudent());
        }

        private void BtnAddEvaluation_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddEvaluation());
        }

        private void BtnListStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageStudentList());
        }

        private void BtnEditGradeStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageEditGrade());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageDeleteStudent());
        }

        private void BtnMvc_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMVC());
        }
    }
}
