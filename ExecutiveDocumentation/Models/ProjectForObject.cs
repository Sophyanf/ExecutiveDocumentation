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

        public override string ToString()
        {
            if (this != null)
                return "Шифр проекта - " + Shifr + " (" + projektСompany + ")";
            else return "Данные проекта";
        }
    }
}