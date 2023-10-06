using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class Kontragent : IDataObject
    {
        public int ID { get; set; }
        public string KontragentName { get; set; }
        public string KontragentShortName { get; set; }
        public string KontragentINN { get; set; }
        public string KontragentOGRN { get; set; }
        public string KontragentAdress { get; set; }
        public ICollection<ConstructionObject> ConstructionObjects { get; set; } = new List<ConstructionObject>();
        public ICollection<ProjectForObject> ProjectForObjects { get; set; } = new List<ProjectForObject>();

        public override string ToString()
        {
            return KontragentShortName;
        }
    }
}
