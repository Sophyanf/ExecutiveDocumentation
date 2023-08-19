using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.ViewModels;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;
using Label = System.Windows.Controls.Label;

namespace ExecutiveDocumentation.Views
{
   
    public partial class MainWindow : System.Windows.Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();

        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in aktHiddenWorkForPrint)
            {
                printAkt(item);
            }
            MessageBox.Show("Завершено");

        }*/

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "файл Excel (Spisok.xlsx)|*.xlsx";
            ofd.Title = "Выберите файл базы данных";
            ofd.ShowDialog();
            var helper = new ExcelHelper(ofd.FileName);
            helper.ProcessLoadFromExcel(aktHiddenWorkForPrint);*/
        }

      /*  private void LoadExcelFile(string fileName)
        {
            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(fileName);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
            for (int j = 2; j < 4; j++) {
                AktHiddenWork aktHiddenWork = new AktHiddenWork();
                for (int i = 1; i < 11; i++)
                {
                    var value = ObjWorkSheet.Cells[j, i].Value;
                   
                   
                    switch (i)
                    {
                        case 1:
                            aktHiddenWork.ID = value.ToString();
                            break;
                        case 2:
                            aktHiddenWork.DayStart = value.ToString();
                            break;
                        case 3:
                            aktHiddenWork.DayEnd = value.ToString();
                            break;
                        case 4:
                            aktHiddenWork.Month = value;
                            break;
                        case 5:
                            aktHiddenWork.Year = value.ToString();
                            break;
                        case 6:
                            aktHiddenWork.WorkType = value;
                            break;
                        case 7:
                            aktHiddenWork.ProjectFounder = value;
                            break;
                        case 8:
                            aktHiddenWork.Certificate = value;
                            break;
                        case 9:
                            aktHiddenWork.TechRelevant = value;
                            break;
                        case 10:
                            aktHiddenWork.NextWork = value;
                            break;
                        case 11:
                            aktHiddenWork.DocRelevant = value;
                            break;

                    }
                    
                }
                aktHiddenWorkForPrint.Add(aktHiddenWork);
            }
            String str = "";
            foreach (var item in aktHiddenWorkForPrint)
            {
                str += item.WorkType + " - " + item.WorkType + Environment.NewLine + Environment.NewLine;
            }
            MessageBox.Show(str);
            ObjWorkExcel.ActiveWorkbook.Close();
            ObjWorkExcel.Quit();
            
        }*/

       
    }
    }

