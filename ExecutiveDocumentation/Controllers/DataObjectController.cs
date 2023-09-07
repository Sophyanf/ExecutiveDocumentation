using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Controllers
{
    internal class DataObjectController
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
     
        public async Task<bool> AddDataObjAsync(IDataObject obj)   //добавление в таблицу
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

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Kontragent>> GetListKontragentAsync()          //Список категорий (по возможности заменить на GetDataProductAsync(string dataType) ))
        {
            List<Kontragent> result = null;

            await Task.Run(() =>
            {
                result = _context.Kontragents.ToList();
            });
            return result;
        }
    }
}
