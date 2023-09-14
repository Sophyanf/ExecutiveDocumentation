using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
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

namespace ExecutiveDocumentation.ViewModels
{
    public class ObjectAddViewVM : BaseViewModel { 
        public ActionCommand AddNewProject { get; set; }
        public ActionCommand DeleteProject { get; set; }
        public ProjectForObject ProjectStr { get; set; }
        private ObservableCollection<ProjectForObject> projects;
        public ObservableCollection<ProjectForObject> Projects

        {
            get { return projects; }
            set
            {
                projects = value;
                OnPropertyChanged();
            }
        }

        public ObjectAddViewVM()
        {
            AddNewProject = new ActionCommand(x => addNewProject());
            Kontragents = new ObservableCollection<Kontragent>();
            LoadKontragentsAsync();
                   }

        private void addNewProject()
        {
            ProjectForObjectAddView projectView = new ProjectForObjectAddView();
            projectView.ShowDialog();
            LoadProjectAsync();
          //  ProjectStr = Projects.LastOrDefault();
        }

        protected async void LoadProjectAsync()
        {
            await Task.Run(async () =>
            {
                Projects = await dataObj.GetListProjectsAsync();
            });
        }
        private  void addNewObj ()
        {
           
        }
    }
}
