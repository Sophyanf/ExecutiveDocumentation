using ExecutiveDocumentation.Enums;
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
        public Adress ObjectAdress { get; set; }     //связь 1:1
        public Kontragent ConstructionOrganization { get; set; } //Подрядчик НГМ //связь 1:1
        public Kontragent ConstructionOrganizationSub { get; set; } //Субподрядчик //связь 1:1
        public Kontragent Customer { get; set; } //Заказчик //связь 1:1
        public DateTime EndDate { get; set; } //связь 1:1
        public int CostOfObject { get; set; } //цена объекта
        public int SpendingOfObject { get; set; }  //сумма субподряда (затраты)
        public KadastrID KadastrID { get; set; }  //может быть null //связь 1:1
        public  TypeOfObject TypeOfObject { get; set; }  //может быть null //связь 1:1
        public ResponsiblPerson CustomerOrgRespPerson { get; set; }    //связь 1(CustomerOrgRespPerson):много(ResponsiblPerson)// подписант
        public StatusOfObject Status { get; set; } = StatusOfObject.InWork; // enum
        public string? Comment { get; set; }
        public OriginDocumentStatus IsOriginDocuments { get; set; }
        public OriginDocumentStatus IsOriginDocumentsSub { get; set;}
        public int PaymentInvoice { get; set; } // счет на оплату
        public int Invoice { get; set; } // счет-фактура
        public Contract Contract { get; set; }

    }
}
