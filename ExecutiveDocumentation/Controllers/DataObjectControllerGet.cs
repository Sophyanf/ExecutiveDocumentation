using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Controllers
{
    public class DataObjectControllerGet
    {
        private readonly AppDbContext _context;
        /*  public static string manufData = "manufacturer";
          public static string categoryData = "categoryBakery";
          private DataObjectController data = DataObjectController.Instance;*/
        public static DataObjectControllerGet Instance { get => DataObjectControllerCreate.instance; }
        private DataObjectControllerGet()
        {
            _context = new AppDbContext();
        }
        private class DataObjectControllerCreate
        {
            static DataObjectControllerCreate() { }
            internal static readonly DataObjectControllerGet instance = new DataObjectControllerGet();
        }

       

        public List<Kontragent> GetListKontragent()          //Список контрагентов
        {
            IEnumerable<Kontragent> result;
            result = _context.Kontragents.ToList();
            return (List<Kontragent>)result;
        }

        public Kontragent GetObjectKontragent(IDataObject dataObject)
        {
            if (dataObject is ConstructionObject co)
            {
                return _context.Kontragents
                    .Include("ConstructionObjects")
                    .FirstOrDefault(k => k.ConstructionObjects.Any(coInner => coInner.ID == co.ID));
            }

            if (dataObject is ProjectForObject proj)
            {
                return _context.Kontragents
                    .Include("ProjectForObjects")
                    .FirstOrDefault(k => k.ProjectForObjects.Any(pInner => pInner.ID == proj.ID));
            }

            if (dataObject is ResponsiblPerson rp)
            {
                return _context.Kontragents
                    .Include("ResponsiblPersons")
                    .FirstOrDefault(k => k.ResponsiblPersons.Any(rpInner => rpInner.ID == rp.ID));
            }

            return null;
        }


        public List<ConstructionObject> GetListConstructionObjects()          //Список объектов
        {
            IEnumerable<ConstructionObject> result;

            result = _context.ConstructionObjects.ToList();
            foreach (var item in result)
            {
                item.Customer = GetObjectKontragent(item);
            }
            return (List<ConstructionObject>)result;
        }

        public List<ResponsiblPerson> GetListPersons()          //Список ответственных лиц
        {
            IEnumerable<ResponsiblPerson> result;

            result = _context.ResponsiblPersons.ToList();
            foreach (var item in result)
            {
                item.PersonKontragent = GetObjectKontragent(item);
            }
            return (List<ResponsiblPerson>)result;
        }



        public async Task<ObservableCollection<IDataObject>> GetListWorksAsync()
        {     
            IQueryable<IDataObject> result = null;

            await Task.Run(() =>
            {
                result = _context.WorkTypes;
            });

            return new ObservableCollection<IDataObject>(result);
        }

        public ObservableCollection<IDataObject> GetListWorks()
        { 
            IQueryable<IDataObject> result;
            result = _context.WorkTypes;

            return new ObservableCollection<IDataObject>(result);
        }

       
    }
}
