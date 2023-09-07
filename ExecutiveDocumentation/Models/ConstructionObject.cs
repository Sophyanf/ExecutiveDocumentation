using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class ConstructionObject : IDataObject
    {
        public int ID { get; set; }
        public WorksTipeObg ListOfWorks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ObjectName { get; set; }
        public string ObjectAdress { get; set; }
        public Kontragent ConstructionOrganization { get; set; } //Подрядчик НГМ
        public Kontragent customer { get; set; } //Заказчик
        public ProjectForObject project { get; set; }

    }
}
