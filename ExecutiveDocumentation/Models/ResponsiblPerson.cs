using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class ResponsiblPerson : IDataObject
    {
        public int ID { get; set; }
        public string personFIO { get; set; }
        public string personPost { get; set; }
        public string personDocument  { get; set; }
        public Kontragent personKontragent { get; set; }
    }
}
