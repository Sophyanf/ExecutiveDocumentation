using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.OthersClasses;
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
            //fillListBox();
            
            AddNewTypeOfWork = new ActionCommand(x => AddNewTypeOfWorkButtonAsync());
            AddNewTypeOfWork = new ActionCommand(x => AddNewTypeOfWorkToDB());
            SelectTypeOfWork = new ActionCommand(x => creatWorksList());
        
        }
        ObservableCollection <IDataObject> checkingWorks { get; set; }
        private ObservableCollection<TypeOfWork> selectWorks;
        public ObservableCollection<TypeOfWork> SelectWorks

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
         /*   checkingWorks = dataObj.GetListWorks();
            if (SelectWorks == null) { SelectWorks = new ObservableCollection<IDataObject>(); }
            foreach (var work in checkingWorks)
            {
                CheckingWorks checkingWorks = new CheckingWorks() { Object = work as WorkType };
                SelectWorks.Add(checkingWorks);
            }*/
        }

        public void AddNewTypeOfWorkButtonAsync()
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

        private DateTime dateOfWork;
        public DateTime DateOfWork
        {
            get { return dateOfWork; }
            set
            {
                dateOfWork = value;
                OnPropertyChanged();
            }
        }


        public void AddNewTypeOfWorkToDB()
        {
            if (selectWorks == null) { selectWorks = new ObservableCollection<TypeOfWork>(); }
            TypeOfWork typeOfWork = new TypeOfWork()
            {
                Name = workName,
                DateOfWork = dateOfWork
            };
            selectWorks.Add(typeOfWork);
        }

        public void creatWorksList ()
        {
            /*MessageBox.Show("Check");
            foreach (CheckingWorks work in SelectWorks) {
                if (work.CheckObj == true) MessageBox.Show(work.Object.Name.ToString());
            }*/
        } 
    }
}
