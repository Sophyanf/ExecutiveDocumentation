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
using Window = System.Windows.Window;

namespace ExecutiveDocumentation.Views
{
    /// <summary>
    /// Логика взаимодействия для AddNewObject.xaml
    /// </summary>
    public partial class ObjectAddView : Window
    {
        private DataObjectController dataObj = DataObjectController.Instance;
        public ObjectAddView()
        {
            InitializeComponent();
            
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ConstructionObject newObj = new ConstructionObject()
            {
                ObjectName = tbName.Text,
                ObjectAdress = tbAdress.Text,
                StartDate = (DateTime)dpStart.SelectedDate,
                EndDate = (DateTime)dpFinish.SelectedDate,
            };
            await dataObj.AddDataObjAsync(newObj);
            DialogResult = true;
        }

        private void kontragent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kontragent.SelectedIndex == 0)
            {
                KontragentAddView addNewKontragent = new KontragentAddView();
                addNewKontragent.ShowDialog();
            }
        }
        
    }
}
