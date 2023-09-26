using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.ViewModels
{
    public class ListOfWorksVM : BaseViewModel
    {
        public ActionCommand AddNewTypeOfWork { get; set; }

        public ListOfWorksVM()
        {
            AddNewTypeOfWork = new ActionCommand(x => addNewTypeOfWork());
        }

        private void addNewTypeOfWorkBu()
        {
            throw new NotImplementedException();
        }
    }
}
