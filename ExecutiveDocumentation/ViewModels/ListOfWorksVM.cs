﻿using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExecutiveDocumentation.ViewModels
{
    public class ListOfWorksVM : BaseViewModel
    {
        public ActionCommand AddNewTypeOfWork { get; set; }
        public ActionCommand AddNewTypeOfWorkDB { get; set; }
        public ActionCommand SelectTypeOfWork { get; set; }


        public ListOfWorksVM()
        {
            fillListBox();
            
            AddNewTypeOfWork = new ActionCommand(x => AddNewTypeOfWorkButtonAsync());
            AddNewTypeOfWorkDB = new ActionCommand(x => AddNewTypeOfWorkToDBAsync());
            SelectTypeOfWork = new ActionCommand(x => creatWorksList());
        
        }
        ObservableCollection <IDataObject> checkingWorks { get; set; }
        private ObservableCollection<IDataObject> selectWorks;
        public ObservableCollection<IDataObject> SelectWorks

        {
            get { return selectWorks; }
            set
            {
                selectWorks = value;
                OnPropertyChanged();
            }
        }
        private void fillListBox()
        {
            checkingWorks = dataObj.GetListWorks();
            if (SelectWorks == null) { SelectWorks = new ObservableCollection<IDataObject>(); }
            foreach (var work in checkingWorks)
            {
                CheckingWorks checkingWorks = new CheckingWorks() { Object = work as WorkType };
                SelectWorks.Add(checkingWorks);
            }
        }

        public async Task AddNewTypeOfWorkButtonAsync()
        {
            
            NewTypeOfWork newTypeOfWork = new NewTypeOfWork();
            newTypeOfWork.ShowDialog();
        }

        
        private String workName;
        public String WorkName
        {
            get { return workName; }
            set
            {
                workName = value;
                OnPropertyChanged();
            }
        }

       
        public async void AddNewTypeOfWorkToDBAsync()
        {
            WorkType workType = new WorkType();
            workType.Name = WorkName;

            bool rez = false;
            await Task.Run(async () =>
            {
                rez = await dataObj.AddObjectPropertiesAsync(workType, SelectKontragent);
            });
            if (rez == false)
            {
                MessageBox.Show("Ошибка!!! Проверьте проект");
                return;
            }
            else Application.Current.Windows.OfType<Window>().SingleOrDefault(y => y.IsActive).Close();
        }

        public void creatWorksList ()
        {
            MessageBox.Show("Check");
            foreach (CheckingWorks work in SelectWorks) {
                if (work.CheckObj == true) MessageBox.Show(work.Object.Name.ToString());
            }
        } 
    }
}
