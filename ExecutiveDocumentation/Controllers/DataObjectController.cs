using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExecutiveDocumentation.Controllers
{
    public class DataObjectController
    {
        private readonly AppDbContext _context;
        /*  public static string manufData = "manufacturer";
          public static string categoryData = "categoryBakery";
          private DataObjectController data = DataObjectController.Instance;*/
        public static DataObjectController Instance { get => DataObjectControllerCreate.instance; }
        private DataObjectController()
        {
            _context = new AppDbContext();
        }
        private class DataObjectControllerCreate
        {
            static DataObjectControllerCreate() { }
            internal static readonly DataObjectController instance = new DataObjectController();
        }

        public async Task<bool> AddDataObjAsync(IDataObject obj)   //добавление в таблицы
        {
            try
            {

                if (obj is ConstructionObject)
                {
                    var dataObj = obj as ConstructionObject;
                    _context.ConstructionObjects.Add(dataObj);
                }
                else if (obj is Kontragent)
                {
                    var dataObj = obj as Kontragent;
                    _context.Kontragents.Add(dataObj);
                }
                else if (obj is ProjectForObject)
                {
                    var dataObj = obj as ProjectForObject;
                    _context.ProjectForObjects.Add(dataObj);
                }
                else if (obj is WorkType)
                {
                    var dataObj = obj as WorkType;
                    _context.WorkTypes.Add(dataObj);
                }

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Kontragent> GetListKontragent()          //Список контрагентов
        {
            IEnumerable<Kontragent> result = null;

            result = _context.Kontragents.ToList();

            return (List<Kontragent>)result;
        }

        public Kontragent GetObjectKontragent(IDataObject dataObject)          //Получить контрагента конкретного объекта
        {
            Kontragent result = null;

            if (dataObject is ConstructionObject)
                result = _context.Kontragents.Include("ConstructionObjects").FirstOrDefault(k => k.ConstructionObjects.Where(co => co.ID == ((ConstructionObject)dataObject).ID).Any());
            else if (dataObject is ProjectForObject)
                result = _context.Kontragents.Include("ProjectForObjects").FirstOrDefault(k => k.ConstructionObjects.Where(co => co.ID == ((ProjectForObject)dataObject).ID).Any());
            return result;
        }
    

            public ProjectForObject GetProjectForObject(ConstructionObject constructionObject)          //Получить проект объекта
            {
                ProjectForObject result = null;

               result = _context.ProjectForObjects.Include("ConstructionObjects").FirstOrDefault(k => k.ConstructionObjects.Where(co=>co.ID == constructionObject.ID).Any());
                result.ProjektСompany = GetObjectKontragent(result);
                
            return result;
            }

            public List<ConstructionObject> GetListConstructionObjects()          //Список объектов
        {
            IEnumerable<ConstructionObject> result;
                
                    result = _context.ConstructionObjects.ToList();
                    foreach (var item in result)
                    {
                        item.Customer = GetObjectKontragent(item);
                        item.ProjectForObject = GetProjectForObject(item);
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
        {         //Список работ
            IQueryable<IDataObject> result = null;

            await Task.Run(() =>
            {
                result = _context.WorkTypes;
            });

            return new ObservableCollection<IDataObject>(result);
        }

        public ObservableCollection<IDataObject> GetListWorks() {         //Список работ
            IQueryable<IDataObject> result = null;
                result = _context.WorkTypes;

            return new ObservableCollection<IDataObject>(result);
        }

        public async Task<bool> AddObjectPropertiesAsync(IDataObject obj, Kontragent kontragent)  // Добавление свойств в базу данных
        {
            try
            {
                if (obj is ConstructionObject)
                {
                    var dataObj = obj as ConstructionObject;
                    _context.Kontragents.Include("ConstructionObjects").FirstOrDefault(k => k.ID == kontragent.ID).ConstructionObjects.Add(dataObj);
                }
                else if (obj is Kontragent)
                {
                    var dataObj = obj as Kontragent;
                    _context.Kontragents.Add(dataObj);
                }
                else if (obj is ProjectForObject)
                {
                    var dataObj = obj as ProjectForObject;
                   _context.Kontragents.Include("ProjectForObjects").FirstOrDefault(k => k.ID == kontragent.ID).ProjectForObjects.Add(dataObj);
                }
                else if (obj is WorkType)
                {
                    var dataObj = obj as WorkType;
                    _context.WorkTypes.Add(dataObj);
                }
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddObjectAsync(ConstructionObject obj, Kontragent kontragent)  // Добавление объекта
        {
            try
            {
               
                    _context.Kontragents.Include("ConstructionObjects").FirstOrDefault(k => k.ID == kontragent.ID).ConstructionObjects.Add(obj);
                //_context.Kontragents.Include("WorkTypes").FirstOrDefault(k => k.ID == workType.Id).ConstructionObjects.Add(obj);


                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    
    public async Task<bool> AddPersonAsync(ResponsiblPerson obj, Kontragent kontragent)  // Добавление объекта
    {
        try
        {
                MessageBox.Show("Ob]ect add");
                _context.Kontragents.Include("ResponsiblPersons").FirstOrDefault(k => k.ID == kontragent.ID).ResponsiblPersons.Add(obj);

                MessageBox.Show("Ob]ect add контрагент");

                await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
}
