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
    /// Логика взаимодействия для PageDeleteStudent.xaml
    /// </summary>
    public partial class PageDeleteStudent : Page
    {
        public PageDeleteStudent()
        {
            InitializeComponent();
            CmbSelectGroup.SelectedValuePath = "ID";
            CmbSelectGroup.DisplayMemberPath = "Name";
            CmbSelectGroup.ItemsSource = odbconnecthelper.entObj.NameGroup.ToList();

            GridList.ItemsSource = odbconnecthelper.entObj.Student.ToList();

        }

        private void CmbSelectGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroupStudent = Convert.ToInt32(CmbSelectGroup.SelectedValue);
            GridList.ItemsSource = odbconnecthelper.entObj.Student.Where(x => x.IDNameGroup == SelectGroupStudent).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridList.SelectedItems.Count > 0)
                {
                    for (int i=0; i < GridList.SelectedItems.Count; i++)
                    {
                        Student StudentObj = GridList.SelectedItems[i] as Student;
                        odbconnecthelper.entObj.Student.Remove(StudentObj);
                    }
                    odbconnecthelper.entObj.SaveChanges();
                    MessageBox.Show(
                       "Данные о студенте успешно удалены!",
                       "Уведомления",
                       MessageBoxButton.OK,
                       MessageBoxImage.Information
                       );
                    GridList.ItemsSource = odbconnecthelper.entObj.Student.ToList();
                }
               else{
                MessageBox.Show(
                   "Данных в таблице нет!",
                   "Уведомления",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
                   );
                }
            }
            
            catch (Exception ex) {
                MessageBox.Show(
                    "Критическая работа приложения: " + ex.Message.ToLower(),
                    "Уведомления",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
