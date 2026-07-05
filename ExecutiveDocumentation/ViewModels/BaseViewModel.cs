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
using System.Windows.Controls;
using Application = System.Windows.Application;
using Window = System.Windows.Window;

namespace ExecutiveDocumentation.ViewModels
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        public int ScreenHeight { get; set; } = (int)SystemParameters.MaximizedPrimaryScreenHeight;
        public int ScreenWidth { get; set; } = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
        public int MainStackPanel { get; set; } = (int)SystemParameters.MaximizedPrimaryScreenHeight - 160;


        protected DataObjectControllerAdd dataObjAdd = DataObjectControllerAdd.Instance;
        protected DataObjectControllerGet dataObjGet = DataObjectControllerGet.Instance;
        protected DataObjectControllerRemove dataObjRemove = DataObjectControllerRemove.Instance;


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
        
        protected void LoadKontragents()
        {
            Kontragents = new ObservableCollection<Kontragent>(dataObjGet.GetListKontragent());
        }

        #endregion

        #region Objects
        private ObservableCollection<ConstructionObject> objectsList;
        public ObservableCollection<ConstructionObject> ObjectsList

        {
            get { return objectsList; }
            set
            {
                objectsList = value;
                OnPropertyChanged(); 
            }
        }
        protected void LoadObjects()
        {
            try
            {
                ObjectsList = new ObservableCollection<ConstructionObject>(dataObjGet.GetListConstructionObjects());
            }
            catch (Exception) { }


        }
        public ObservableCollection<ResponsiblPerson> personsList;
        public ObservableCollection<ResponsiblPerson> PersonsList

        {
            get { return personsList; }
            set
            {
                personsList = value;
                OnPropertyChanged();
            }
        }

        protected void LoadPersens()
        {
            try
            {
                PersonsList = new ObservableCollection<ResponsiblPerson>(dataObjGet.GetListPersons());
            }
            catch (Exception) { }


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

        ResponsiblPerson thisPerson = null;
        public ResponsiblPerson ThisPerson
        {
            get { return thisPerson; }
            set
            {
                thisPerson = value;
                OnPropertyChanged();
            }
        }

        private ConstructionObject selectObject;
        public ConstructionObject SelectObject
        {
            get { return selectObject; }
            set
            {
                selectObject = value;
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
            AddKontragentView AddKontragentView = new AddKontragentView();
            AddKontragentView.ShowDialog();
            LoadKontragents();
        }

        public void RemoveConstractionObject() { }
    }
}
