using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation
{
    public class CheckingWorks : IDataObject
    {
        public WorkType Object { get; set; }
        public bool CheckObj { get; set; } = false;

    }
}
