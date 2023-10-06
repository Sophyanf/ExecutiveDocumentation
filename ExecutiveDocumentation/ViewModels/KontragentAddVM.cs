using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExecutiveDocumentation.ViewModels
{
    public class KontragentAddVM : BaseViewModel
    {
        public ActionCommand AddNewKontragent { get; set; }

        private String kontragentName;
        public String KontragentName
        {
            get { return kontragentName; }
            set
            {
                kontragentName = value;
                OnPropertyChanged();
            }
        }

        private String kontragentShortName;
        public String KontragentShortName
        {
            get { return kontragentShortName; }
            set
            {
                kontragentShortName = value;
                OnPropertyChanged();
            }
        }

        private String kontragentINN;
        public String KontragenINN
        {
            get { return kontragentINN; }
            set
            {
                kontragentINN = value;
                OnPropertyChanged();
            }
        }

        private String kontragentAdress;
        public String KontragentAdress
        {
            get { return kontragentAdress; }
            set
            {
                kontragentAdress = value;
                OnPropertyChanged();
            }
        }

        private String kontragentOGRN;
        public String KontragenOGRN
        {
            get { return kontragentOGRN; }
            set
            {
                kontragentOGRN = value;
                OnPropertyChanged();
            }
        }

        private async void AddKontragentAsync()
        {
            Kontragent kontragent = new Kontragent()
            {
                    KontragentName = this.kontragentName,
                    KontragentShortName = this.KontragentShortName,
                    KontragentAdress = this.kontragentAdress,
                    KontragentINN = this.kontragentINN,
                    KontragentOGRN=this.kontragentOGRN,
            };

            if (await dataObj.AddDataObjAsync(kontragent) == false)
            {
                MessageBox.Show("Ошибка!!! Проверьте категорию");
            }
            else Application.Current.Windows.OfType<Window>().SingleOrDefault(y => y.IsActive).Close();
        }

        public KontragentAddVM ()
        {
            AddNewKontragent = new ActionCommand(x => AddKontragentAsync());
        }
    }
}
