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
        public ActionCommand AddWorksList{ get; set; }
        public ActionCommand DeleteProject { get; set; }

         ProjectForObject projectStr = null;
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

        private ObservableCollection<ProjectForObject> worksList;
        public ObservableCollection<ProjectForObject> WorksList

        {
            get { return worksList; }
            set
            {
                worksList = value;
                OnPropertyChanged();
            }
        }

        bool flagProject;
        public bool FlagProject
        {

            get { return flagProject; }
            set
            {
                flagProject = value;
                OnPropertyChanged();
            }
        }
        bool flagListOfWorks;
        public bool FlagListOfWorks
        {

            get { return flagListOfWorks; }
            set
            {
                flagListOfWorks = value;
                OnPropertyChanged();
            }
        }

        public ObjectAddViewVM()
        {
            
            AddNewProject = new ActionCommand(x => addNewProject());
            AddWorksList = new ActionCommand(x => addWorksList());ghbn
            Kontragents = new ObservableCollection<Kontragent>();
            LoadKontragentsAsync();
            FlagProject = true;
            FlagListOfWorks = true;
        }

        private async void addNewProject()
        {
            FlagProject = false;
            ProjectForObjectAddView projectView = new ProjectForObjectAddView();
            projectView.ShowDialog();
            await LoadProjectAsync();
            ProjectStr = new ProjectForObject();
            ProjectStr = Projects.LastOrDefault();
            MessageBox.Show(ProjectStr.ToString());
        }

        private async void addWorksList()
        {
            FlagProject = false;
            ListOfWorksView worksView = new ListOfWorksView();
            worksView.ShowDialog();
            await LoadProjectAsync();
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
        }

        protected async Task LoadWorksAsync()
        {
            Projects = new ObservableCollection<ProjectForObject>();
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
