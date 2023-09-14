using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Models;
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected DataObjectController dataObj = DataObjectController.Instance;
        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        protected virtual void UpdateValue<T>(ref T field, T value, [CallerMemberName] string property = "")
        {
            field = value;
            OnPropertyChanged(property);
        }

        public virtual ActionCommand CloseAppCommand => new ActionCommand(x => Application.Current.Shutdown());
        public virtual ActionCommand CloseWindowCommand => new ActionCommand(x => Application.Current.Windows.OfType<Window>().SingleOrDefault(y => y.IsActive).Close());
        public virtual ActionCommand WindowMinimizeCommand => new ActionCommand(x => MinimizeWindow());
        public virtual ActionCommand WindowMaximizeCommand => new ActionCommand(x => MaximizeWindow());

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

        protected async void LoadKontragentsAsync()
        {
            await Task.Run(async () =>
            {
                Kontragents = await dataObj.GetListKontragentAsync();
            });
        }
    }
}
