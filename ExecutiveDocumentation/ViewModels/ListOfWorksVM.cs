using ExecutiveDocumentation.Models;
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
            SelectWorks =  dataObj.GetListWorks();
            AddNewTypeOfWork = new ActionCommand(x => AddNewTypeOfWorkButtonAsync());
            AddNewTypeOfWorkDB = new ActionCommand(x => AddNewTypeOfWorkToDBAsync());
            SelectTypeOfWork = new ActionCommand(x => creatWorksList());
        
        }

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

        private List<int> isSelectList;
        public List<int> IsSelectList
        {
            get { return isSelectList; }
            set
            {
                isSelectList = value;
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
            MessageBox.Show(IsSelectList.ToString());
        } 
    }
}
