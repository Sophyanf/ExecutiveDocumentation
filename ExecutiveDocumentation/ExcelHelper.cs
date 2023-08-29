using ExecutiveDocumentation.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExecutiveDocumentation
{
    public class ExcelHelper
    {
        FileInfo fileInfo;
        Excel.Application app = null;
        AktHiddenWork aktHiddenWork = null;
        Excel.Worksheet appSheet = null;

        public ExcelHelper (string fileName)
        {
            if (File.Exists(fileName))
            {
                fileInfo = new FileInfo(fileName);
            }
            else { throw new ArgumentException("File not found"); }
        }

        public void ProcessLoadFromExcel ( List<AktHiddenWork> aktHiddenWorkForPrint)
        {
            app = new Excel.Application();
            Excel.Workbook appDocument = app.Workbooks.Open(fileInfo.FullName);
            appSheet = (Excel.Worksheet)appDocument.Sheets[1]; //получить 1-й лист
            for (int j = 2; j < 4; j++)
            {
                aktHiddenWork = new AktHiddenWork();
                for (int i = 1; i < 11; i++)  
                {
                    getDataForAkt(j, i);

                }
                aktHiddenWorkForPrint.Add(aktHiddenWork);
            }
            String str = "";
            foreach (var item in aktHiddenWorkForPrint)
            {
                str += item.WorkType + " - " + item.WorkType + Environment.NewLine + Environment.NewLine;
            }
            MessageBox.Show(str);
            app.ActiveWorkbook.Close();
            app.Quit();
        }

        private AktHiddenWork getDataForAkt (int j, int i)
        {
            var value = appSheet.Cells[j, i].Value;


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
            return aktHiddenWork;
        }
    }
}
