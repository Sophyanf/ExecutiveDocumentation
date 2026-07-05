using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class Adress
    {
        public int ID { get; set; }
        public String Objectdress { get; set; }
        public DateTime dateOfChenge { get; set; }
        public ICollection<ConstructionObject> ConstructionObjects { get; set; } = new List<ConstructionObject>();
    }
}
