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

        public ProjectForObject projectStr;
        public ProjectForObject ProjectStr
        {
            get { return projectStr; }
            set
            {
                projectStr = value;
                OnPropertyChanged();
            }
        }
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

        private async void addNewProject()
        {

            ProjectForObjectAddView projectView = new ProjectForObjectAddView();
            projectView.ShowDialog();
            await LoadProjectAsync();
            // foreach (var project in Projects) { MessageBox.Show(project.ToString() + " !!!!!"); }
            ProjectStr = new ProjectForObject();
            ProjectStr = Projects.LastOrDefault();
            MessageBox.Show(ProjectStr.ToString());

        }

        protected async Task LoadProjectAsync()
        {
            Projects = new ObservableCollection<ProjectForObject>();
            await Task.Run(async () =>
            {
                
                Projects = await dataObj.GetListProjectsAsync();
               
            });
            //foreach (var project in Projects) { MessageBox.Show(project.ToString() + " check"); }
        }

       
        private  void addNewObj ()
        {
           
        }
    }
}
