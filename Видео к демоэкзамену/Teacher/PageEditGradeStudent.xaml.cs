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

namespace Видео_к_демоэкзамену.Teacher
{
    /// <summary>
    /// Логика взаимодействия для PageEditGradeStudent.xaml
    /// </summary>
    public partial class PageEditGradeStudent : Page
    {
        private string NameStudent;
        private int StudentID;
        public PageEditGradeStudent(Student student)
        {
            InitializeComponent();

            TxtName.Text = student.Name;
            NameStudent = student.Name;

            StudentID = student.ID;

            ListJournal.ItemsSource = odbconnecthelper.entObj.Journal.Where(x => x.IDStudents == student.ID).ToList();
            ListJournal.SelectedIndex = 0;
            ListJournal.Columns[0].IsReadOnly = true;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            History histroryObj = new History()
            {
                IDTeacher = UserControlHelp.IDUser,
                IDStudent = StudentID,
                IDStatus = 2,
                DateEvent = DateTime.Now
            };
            odbconnecthelper.entObj.History.Add(histroryObj);
            odbconnecthelper.entObj.SaveChanges();
            MessageBox.Show(
                "Данные успешно измененны у студента " + NameStudent +"!",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
    }
}
