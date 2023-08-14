using ExecutiveDocumentation.ViewModels;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace ExecutiveDocumentation.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WordHalper("TempDog.docx");

            var items = new Dictionary<string, string>
            {
                {"<NAME>", tb1.Text },
                /*{"<URADRESS>",tb2.Text },
                {"<INNKPP>", tb3.Text },
                {"<OGRN>", tb4.Text }*/
               /* <BANK>
                <RSH>
                <KSH>
                <BIC>
                <TEL>
                <MAIL>*/
               
            };
            helper.Process(items);

        }
     
    }
}
