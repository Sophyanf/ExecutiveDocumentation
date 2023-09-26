using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ExecutiveDocumentation.ViewModels
{
    public class ProjectForObjectAddVM : BaseViewModel
    {
        public ActionCommand AddNewProjectDB { get; set; }
        private String projectShifr;
        public String ProjectShifr
        {
            get { return projectShifr; }
            set 
            { 
                projectShifr = value;
                OnPropertyChanged();
            }
        }
        private Kontragent projectKontragent;
        public Kontragent ProjectKontragent
        {
            get { return projectKontragent; }
            set
            {
                projectKontragent = value;
                OnPropertyChanged();
            }
        }
        public ProjectForObjectAddVM ()
        {
            AddNewProjectDB  = new ActionCommand(x => addNewProjectDBAsync());
            LoadKontragentsAsync();
        }

        private async void addNewProjectDBAsync()
        {
            ProjectForObject newProduct = new ProjectForObject()// создаем новый проект из текстбоксов и пр.
            {
                Shifr = projectShifr,
                projektСompany = ProjectKontragent
            };

           
            bool rez = false;
            await Task.Run(async () =>
            {
                rez = await dataObj.AddProjectAsync(newProduct, ProjectKontragent);
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
