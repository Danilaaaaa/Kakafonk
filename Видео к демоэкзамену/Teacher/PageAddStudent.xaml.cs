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
    /// Логика взаимодействия для PageAddStudent.xaml
    /// </summary>
    public partial class PageAddStudent : Page
    {
        public PageAddStudent()
        {
            InitializeComponent();

            CmbSpecial.SelectedValuePath = "ID";
            CmbSpecial.DisplayMemberPath = "Name";
            CmbSpecial.ItemsSource = odbconnecthelper.entObj.Special.ToList();

            CmbFormTime.SelectedValuePath = "ID";
            CmbFormTime.DisplayMemberPath = "Name";
            CmbFormTime.ItemsSource = odbconnecthelper.entObj.FormTime.ToList();

            CmbYear.SelectedValuePath = "ID";
            CmbYear.DisplayMemberPath = "Year";
            CmbYear.ItemsSource = odbconnecthelper.entObj.YearAdd.ToList();

            CmbNameGroup.SelectedValuePath = "ID";
            CmbNameGroup.DisplayMemberPath = "Name";
            CmbNameGroup.ItemsSource = odbconnecthelper.entObj.NameGroup.ToList();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student stdObj = new Student()
                {
                    Name = TxbNameStudent.Text,
                    NameGroup = CmbNameGroup.SelectedItem as NameGroup,
                    Special = CmbSpecial.SelectedItem as Special,
                    FormTime = CmbFormTime.SelectedItem as FormTime,
                    YearAdd = CmbYear.SelectedItem as YearAdd
                };

                odbconnecthelper.entObj.Student.Add(stdObj);
                odbconnecthelper.entObj.SaveChanges();
                MessageBox.Show("Студент" + stdObj.Name + " Успешно добавлен!",
                                "Уведомление",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information
                                 );
                FrameApp.frmObj.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Критическая работа с приложением: " + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack(); 
        }
    }
}
