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
    /// Логика взаимодействия для PageAddEvaluation.xaml
    /// </summary>
    public partial class PageAddEvaluation : Page
    {
        public PageAddEvaluation()
        {
            InitializeComponent();

            CmbDiscipline.SelectedValuePath = "ID";
            CmbDiscipline.DisplayMemberPath = "Name";
            CmbDiscipline.ItemsSource = odbconnecthelper.entObj.Discipline.ToList();

            CmbNameStudent.SelectedValuePath = "ID";
            CmbNameStudent.DisplayMemberPath = "Name";

            CmbGroup.SelectedValuePath = "ID";
            CmbGroup.DisplayMemberPath = "Name";
            CmbGroup.ItemsSource = odbconnecthelper.entObj.NameGroup.ToList(); 


        }

        private void BtnAddEvaluation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Journal jourObj = new Journal()
                {
                    Student = CmbNameStudent.SelectedItem as Student,
                    Evaluation = Convert.ToInt32(TxbEvaluation.Text), 
                    Discipline = CmbDiscipline.SelectedItem as Discipline,
                    NameGroup = CmbGroup.SelectedItem as NameGroup
                };

                odbconnecthelper.entObj.Journal.Add(jourObj);
                odbconnecthelper.entObj.SaveChanges();

                MessageBox.Show(
                     "Оценка успешна поставлена!",
                     "Уведомление",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);
                FrameApp.frmObj.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                     "Критическая работа с приложением: " + ex.Message.ToString(),
                     "Уведомление",
                     MessageBoxButton.OK,
                     MessageBoxImage.Warning
                     );
            }
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedGroup = Convert.ToInt32(CmbGroup.SelectedValue);
            CmbNameStudent.ItemsSource = odbconnecthelper.entObj.Student.Where(x => x.IDNameGroup == SelectedGroup).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void TxbEvaluation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "2345".IndexOf(e.Text) < 0;
        }

        private void TxbEvaluation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Convert.ToInt32(TxbEvaluation.Text) >= 2 &&
                Convert.ToInt32(TxbEvaluation.Text) <= 5)
            {
                TxbEvaluation.Background = Brushes.LightGreen;
                TxbEvaluation.BorderBrush = Brushes.Green;
                BtnAddEvaluation.IsEnabled = true;
            }
            else
            {
                TxbEvaluation.Background = Brushes.LightCoral;
                TxbEvaluation.BorderBrush = Brushes.Red;
                BtnAddEvaluation.IsEnabled = false;
            }
        }
    }
}
