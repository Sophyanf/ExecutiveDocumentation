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
    }
}
