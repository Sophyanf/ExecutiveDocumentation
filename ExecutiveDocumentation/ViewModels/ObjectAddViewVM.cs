using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExecutiveDocumentation.ViewModels
{
    internal class ObjectAddViewVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DataObjectController dataObj = DataObjectController.Instance;
        public List<Kontragent> Kontragents { get; set; } = new List<Kontragent>();
        public ActionCommand AddNewObject { get; set; }

        public ObjectAddViewVM()
        {
            await loadObjectAddViewAsync();
            AddNewObject = new ActionCommand(x => addNewObj());
        }


        private async Task loadObjectAddViewAsync()
        {
            List<Kontragent> kontragentsList = await dataObj.GetListKontragentAsync();
            Kontragents = kontragentsList;
        }

        private async void addNewObj ()
        {
            /* ConstructionObject newObj = new ConstructionObject()
             {
                 ObjectName = tbName.Text,
                 ObjectAdress = tbAdress.Text,
                 StartDate = (DateTime)dpStart.SelectedDate,
                 EndDate = (DateTime)dpFinish.SelectedDate,
             };
             await dataObj.AddDataObjAsync(newObj);
             DialogResult = true;*/
            await loadObjectAddViewAsync();
            String str = "";
            foreach (Kontragent kontragent in Kontragents) { str += kontragent.KontragentShortName + " "; }
            MessageBox.Show(str);
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
