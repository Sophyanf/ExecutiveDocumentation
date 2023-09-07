using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class WorkTipe : IDataObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorksTipeObg> WorksTipeObgObg { get; set; }
    }
}
