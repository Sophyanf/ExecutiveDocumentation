using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;


namespace ExecutiveDocumentation.ViewModels
{
    internal class WordHalper
    {
        FileInfo fileInfo;
        Word.Application app = null;
        public WordHalper(string fileName)
        {
            if (File.Exists(fileName))
            {
               fileInfo= new FileInfo(fileName);
            }
            else { throw new ArgumentException("File not found"); }
        }

        public bool Process(Dictionary<string, string> items)
        {
            try
            {
                app = new Word.Application();
                Object file = fileInfo.FullName;
                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

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

                /* Object newFileName = Path.Combine(fileInfo.DirectoryName,  "1.docx");
                app.ActiveDocument.SaveAs2(newFileName);*/
                app.ActiveDocument.Save();
                app.ActiveDocument.Close();
                return true;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (app!= null) { app.Quit(); }
            }
            
            return false;
        }
    }
} 
