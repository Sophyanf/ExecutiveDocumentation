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

        public MainViewVM()
        {

            AddNewObjectDB = new ActionCommand(x => AddNewObject());
            /*Kontragents = new ObservableCollection<Kontragent>();
            LoadKontragents();
           
            ProjectsList = new ObservableCollection<ProjectForObject>();
            LoadProjects();*/
            ObjectsList = new ObservableCollection<ConstructionObject>();
            LoadObjects();

        }
        private void AddNewObject()
        {
            ObjectAddView objectView = new ObjectAddView();
            objectView.ShowDialog();
        }
    }
}
