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

        public async Task<ObservableCollection<Kontragent>> GetListKontragentAsync()          //Список категорий (по возможности заменить на GetDataProductAsync(string dataType) ))
        {
            IQueryable<Kontragent> result = null;
                await Task.Run(() =>
                {
                    result = _context.Kontragents;
                });
          
                return new ObservableCollection<Kontragent>(result);
        }

        public async Task<ObservableCollection<ProjectForObject>> GetListProjectsAsync()          //Список проектов (по возможности заменить на GetDataProductAsync(string dataType) ))
        {
            IQueryable<ProjectForObject> result = null;

            await Task.Run(() =>
            {
                result = _context.ProjectForObjects;
            });

            return new ObservableCollection<ProjectForObject>(result);
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
    }
}
