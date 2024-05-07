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
    public class ObjectAddViewVM : BaseViewModel {

        #region Commands
        public ActionCommand AddNewProject { get; set; } 
        public ActionCommand AddNewConctrObject { get; set; }
       
        public ActionCommand DeleteProject { get; set; }

      
        private async void AddNewProjectAsinc()
        {
            FlagProject = false;
            ProjectForObjectAddView projectView = new ProjectForObjectAddView();
            projectView.ShowDialog();
            //await LoadProjectAsync();
            ProjectStr = new ProjectForObject();
            ProjectStr = Projects.LastOrDefault();
            MessageBox.Show(ProjectStr.ToString());
        }

        #endregion

        #region ProjectForObject
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
       


        #endregion

        #region WorksList
        private ObservableCollection<WorksTypeObg> worksList;
        public ObservableCollection<WorksTypeObg> WorksList

        {
            get { return worksList; }
            set
            {
                worksList = value;
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

      

      
        #endregion

        #region ObgectProperties
        String objName;
        public String ObjName { get { return objName; } set { objName = value; OnPropertyChanged(); } }

        String objAdress;
        public String ObjAdress { get { return objAdress; } set { objAdress = value; OnPropertyChanged(); } }

        DateTime startDate;
        public DateTime StartDate { get { return startDate; } set { startDate = value; OnPropertyChanged(); } }

        DateTime endDate;
        public DateTime EndDate { get { return endDate; } set { endDate = value; OnPropertyChanged(); } }
        #endregion
        public ObjectAddViewVM()
        {
            
            AddNewProject = new ActionCommand(x => AddNewProjectAsinc());
            AddNewConctrObject = new ActionCommand(x => addNewObj());
            //Kontragents = new ObservableCollection<Kontragent>();
            //LoadKontragentsAsync();
            FlagProject = true;
            FlagListOfWorks = true;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        

        private async void addNewObj ()
        {
            ThisObj = new ConstructionObject()// создаем новый проект из текстбоксов и пр.
            {
                ObjectName = ObjName,
                ObjectAdress = ObjAdress,
                ConstructionOrganization = Kontragents.FirstOrDefault(k => k.KontragentShortName == "НовГазМонтаж"),//Подрядчик НГМ
                Customer = SelectKontragent,  //Заказчик
                ProjectForObject = ProjectStr,
                StartDate = StartDate,
                EndDate = EndDate,
            };


            bool rez = false;
            await Task.Run(async () =>
            {
                rez = await dataObj.AddObjectAsync(ThisObj, SelectKontragent);
            });
            if (rez == false)
            {
                MessageBox.Show("Ошибка!!! Проверьте объект");
                return;
            }
            else Application.Current.Windows.OfType<Window>().SingleOrDefault(y => y.IsActive).Close();
        }
    }
    }
