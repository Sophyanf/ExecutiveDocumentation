using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
using System;
using System.Collections.Generic;
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


        public ListOfWorksVM()
        {
           AddNewTypeOfWork = new ActionCommand(x => AddNewTypeOfWorkButton());
            AddNewTypeOfWorkDB = new ActionCommand(x => AddNewTypeOfWorkToDBAsync());
        }

        public void AddNewTypeOfWorkButton()
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
    }
}
