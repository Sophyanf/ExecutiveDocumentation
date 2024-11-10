using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
using Microsoft.Office.Interop.Excel;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Application = System.Windows.Application;
using Window = System.Windows.Window;

namespace ExecutiveDocumentation.ViewModels
{
   public class MainViewVM : BaseViewModel
    {
     
        public ActionCommand AddNewObjectDB { get; set; }
        public ActionCommand AddPersonDB { get; set; }

        public MainViewVM()
        {
            MessageBox.Show(ScreenWidth.ToString());
            AddNewObjectDB = new ActionCommand(x => AddNewObject());
            AddPersonDB = new ActionCommand(x => AddPerson());
            ObjectsList = new ObservableCollection<ConstructionObject>();
            LoadObjects();
            PersonsList = new ObservableCollection<ResponsiblPerson>();
            LoadPersens();
        }

        private void AddPerson()
        {
            AddResponsiblPerson person = new AddResponsiblPerson();
            person.ShowDialog();
        }

        private void AddNewObject()
        {
            ObjectAddView objectView = new ObjectAddView();
            objectView.ShowDialog();
        }
    }
}
