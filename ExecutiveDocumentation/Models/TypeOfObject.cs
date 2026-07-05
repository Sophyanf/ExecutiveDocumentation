using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExecutiveDocumentation.Models
{
    public class TypeOfObject : IDataObject
    {
        public int ID { get; set; }
        public string TypeName { get; set; } = "";
        public virtual ICollection<ConstructionObject> ConstructionObjects { get; set; } = new List<ConstructionObject>();
    }
}