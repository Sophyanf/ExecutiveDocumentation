using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Models;
using Microsoft.Office.Interop.Word;
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
using System.Windows.Shapes;
using Task = System.Threading.Tasks.Task;
using Window = System.Windows.Window;

namespace ExecutiveDocumentation.Views
{
    /// <summary>
    /// Логика взаимодействия для KontragentAddView.xaml
    /// </summary>
    public partial class KontragentAddView : Window
    {
        private DataObjectController dataObj = DataObjectController.Instance;
        
        public KontragentAddView()
        {
            InitializeComponent();
        }
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {


            if (IsTextNumeric(e.Text))
            {
                e.Handled = true; // Пометьте событие как обработанное, чтобы предотвратить ввод символа
            }
    }

    private bool IsTextNumeric(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddKontragentAsync();
            DialogResult = true;
        }
        private async Task AddKontragentAsync ()
        {
            Kontragent kontragent = new Kontragent()
            {
                KontragentName = tbName.Text,
                KontragentShortName = tbShortName.Text,
                KontragentAdress = tbAdress.Text,
                KontragentINN = tbINN.Text
            };

            if (await dataObj.AddDataObjAsync(kontragent) == false)
            {
                MessageBox.Show("Ошибка!!! Проверьте категорию");
            }
        }
    }
}
