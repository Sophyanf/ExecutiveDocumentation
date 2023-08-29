using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class ConstructionObject
    {
        public int ID { get; set; }
        public string ObjectName { get; set; }
        public string ObjectAdress { get; set; }
        public Kontragent ConstructionOrganization { get; set; }
        public Kontragent customer { get; set; }
        //public ProjectForObject project { get; set; }

    }
}
