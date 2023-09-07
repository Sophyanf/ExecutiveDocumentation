using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class ProjectForObject : IDataObject
    {
        public int ID { get; set; }
        public string Shifr { get; set; }
        public Kontragent projektСompany { get; set; }
    }
}