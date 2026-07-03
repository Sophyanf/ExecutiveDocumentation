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
        public string ObjectName { get; set; }
        public string ObjectAdress { get; set; }
        public Kontragent ConstructionOrganization { get; set; } //Подрядчик НГМ
        public Kontragent Customer { get; set; } //Заказчик
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectForObject ProjectForObject   { get; set; }
        public WorksTypeObg?  ListOfWorks { get; set; }
        public ResponsiblPerson ConstrOrgRespPerson { get; set; }                                // уполномоченный представитель исполнителя (гл. инженер)
        public ResponsiblPerson ConstrOrgBuildRespPerson { get; set; }                          // уполномоченный представитель исполнителя стройконтроль
        public ResponsiblPerson CustomerOrgRespPerson { get; set; }                              // уполномоченный представитель заказчика
        public ResponsiblPerson CustomerOrgBuildRespPerson { get; set; }                        // уполномоченный представитель заказчика стройконтроль
        public ResponsiblPerson ProjectOrgBuildRespPerson { get; set; }                          // проектровщик

    }
}
