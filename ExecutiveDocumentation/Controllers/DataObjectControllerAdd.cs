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
    public class DataObjectControllerAdd
    {
        private readonly AppDbContext _context;
        protected DataObjectControllerGet dataObjGet = DataObjectControllerGet.Instance;
        /*  public static string manufData = "manufacturer";
          public static string categoryData = "categoryBakery";
          private DataObjectController data = DataObjectController.Instance;*/
        public static DataObjectControllerAdd Instance { get => DataObjectControllerCreate.instance; }
        private DataObjectControllerAdd()
        {
            _context = new AppDbContext();
        }
        private class DataObjectControllerCreate
        {
            static DataObjectControllerCreate() { }
            internal static readonly DataObjectControllerAdd instance = new DataObjectControllerAdd();
        }

       


        public async Task<bool> AddProjectAsync(ProjectForObject obj, Kontragent kontragent)  // Добавление свойств в базу данных
        {
            try
            {
               
                _context.Kontragents.Include("ProjectForObjects").FirstOrDefault(k => k.ID == kontragent.ID).ProjectForObjects.Add(obj);
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
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddPersonAsync(ResponsiblPerson obj, Kontragent kontragent)  // Добавление ответственных
        {
            try
            {
                _context.Kontragents.Include("ResponsiblPersons").FirstOrDefault(k => k.ID == kontragent.ID).ResponsiblPersons.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddKontragentAsync(Kontragent obj)  // Добавление контрагента
        {
            try
            {
                _context.Kontragents.Add(obj);
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

