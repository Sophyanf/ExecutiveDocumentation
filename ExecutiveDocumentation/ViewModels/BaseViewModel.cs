using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExecutiveDocumentation.ViewModels
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        protected DataObjectController dataObj = DataObjectController.Instance;

        #region Commands
        public virtual ActionCommand CloseAppCommand => new ActionCommand(x => Application.Current.Shutdown());
        public virtual ActionCommand CloseWindowCommand => new ActionCommand(x => Application.Current.Windows.OfType<Window>().SingleOrDefault(y => y.IsActive).Close());
        public virtual ActionCommand WindowMinimizeCommand => new ActionCommand(x => MinimizeWindow());
        public virtual ActionCommand WindowMaximizeCommand => new ActionCommand(x => MaximizeWindow());

        protected virtual void MaximizeWindow()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState;
            if (currentWindow == WindowState.Normal)
            {
                currentWindow = WindowState.Maximized;
            }
            else
            {
                currentWindow = WindowState.Normal;
            }
        }
        protected virtual void MinimizeWindow()
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Minimized;
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        protected virtual void UpdateValue<T>(ref T field, T value, [CallerMemberName] string property = "")
        {
            field = value;
            OnPropertyChanged(property);
        }
        #endregion
       
        #region Kontragents
        private ObservableCollection<Kontragent> kontragents;
        public ObservableCollection<Kontragent> Kontragents

        {
            get { return kontragents; }
            set
            {
                kontragents = value;
                OnPropertyChanged();
            }
        }
        
        protected async void LoadKontragentsAsync()
        {
            await Task.Run(async () =>
            {
                Kontragents = await dataObj.GetListKontragentAsync();
            });
        }

       
        #endregion

        ConstructionObject thisObj = null;
        public ConstructionObject ThisObj
        {
            get { return thisObj; }
            set
            {
                thisObj = value;
                OnPropertyChanged();
            }
        }

        private Kontragent selectKontragent;
        public Kontragent SelectKontragent
        {
            get { return selectKontragent; }
            set
            {
                selectKontragent = value;
                OnPropertyChanged();
            }
        }

        public ActionCommand AddNewKontragent { get; set; }
        public BaseViewModel ()
        {
            AddNewKontragent = new ActionCommand(x => AddNewKontragentView());
        }
        private void AddNewKontragentView()
        {
            KontragentAddView kontragentAddView = new KontragentAddView();
            kontragentAddView.ShowDialog();
            LoadKontragentsAsync();
        }

    }
}
