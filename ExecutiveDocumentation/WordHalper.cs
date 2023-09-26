using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows;
using File = System.IO.File;
using Word = Microsoft.Office.Interop.Word;


namespace ExecutiveDocumentation.ViewModels
{
    internal class WordHalper
    {
        FileInfo fileInfo;
        Word.Application app = null;
        Object missing = Type.Missing;

        public WordHalper(string fileName)
        {
            if (File.Exists(fileName))
            {
               fileInfo= new FileInfo(fileName);
            }
            else { throw new ArgumentException("File not found"); }
        }

        public bool ProcessFindTeg(Dictionary<string, string> items)
        {
            try
            {
                app = new Word.Application();
                Object file = fileInfo.FullName;
                

                app.Documents.Open(file);
                app.Visible = true;
                MessageBox.Show("");
                foreach (var item in items)
                {
                    findTeg(item.Key, item.Value);
                }
                
                MessageBox.Show("После");

                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.Duplex = Duplex.Vertical;
                app.ActiveDocument.SaveAs2(pd);
                pd.Print();
                app.ActiveDocument.Close( 0);
                return true;
                 }
             
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (app!= null) { app.Quit(); }
            }
            return false;
        }
        
        public void findTeg (string key, string value)
        {
            Word.Find find = app.Selection.Find;
            find.Text = key;
            find.Replacement.Text = value;

            Object wrap = Word.WdFindWrap.wdFindContinue;
            Object replace = Word.WdReplace.wdReplaceAll;
            find.Execute(FindText: Type.Missing,
                MatchCase: false,
                MatchWholeWord: false,
                MatchWildcards: false,
                MatchSoundsLike: missing,
                MatchAllWordForms: false,
                Forward: true,
                Wrap: wrap,
                Format: false,
                ReplaceWith: missing, Replace: replace);
        }
    }
} 
