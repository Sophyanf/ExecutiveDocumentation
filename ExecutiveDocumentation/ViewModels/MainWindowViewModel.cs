using ExecutiveDocumentation.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExecutiveDocumentation.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        

        List<AktHiddenWork> aktHiddenWorkForPrint = new List<AktHiddenWork>();
        public ActionCommand PrintDocumentCommand { get; set; }
        public ActionCommand LoadFromExcelCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public MainWindowViewModel ()
        {
            PrintDocumentCommand = new ActionCommand(x=> PrintDocument());
            LoadFromExcelCommand = new ActionCommand(x => LoadExcelFile());
        }

        
        private void PrintDocument() 
        {
            /*foreach (var item in aktHiddenWorkForPrint)
            {
                printAkt(item);
            }*/
            printAkt(aktHiddenWorkForPrint[0]);
            MessageBox.Show("Завершено");
        }

        private void printAkt(AktHiddenWork aktHiddenWork)
        {
            var helper = new WordHalper("AktHiddenWork.docx");

            var items = new Dictionary<string, string>
            {
                { "<ID>", aktHiddenWork.ID },
                { "<DayStart>", aktHiddenWork.DayStart},
                { "<DayEnd>", aktHiddenWork.DayEnd },
                { "<Month>", aktHiddenWork.Month },
                {"<Year>", aktHiddenWork.Year },
                {"<WorkType>", aktHiddenWork.WorkType },
                {"<ProjectFounder>", aktHiddenWork.ProjectFounder },
                {"<DocRelevant>", aktHiddenWork.DocRelevant },
                {"<TechRelevant>", aktHiddenWork.TechRelevant },
            };
            helper.ProcessFindTeg(items);
        }
        private void LoadExcelFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
           ofd.DefaultExt = "*.xls;*.xlsx";
           ofd.Filter = "файл Excel (Spisok.xlsx)|*.xlsx";
           ofd.Title = "Выберите файл базы данных";
           ofd.ShowDialog();
           var helper = new ExcelHelper(ofd.FileName);
           helper.ProcessLoadFromExcel(aktHiddenWorkForPrint);
        }
    }
}
