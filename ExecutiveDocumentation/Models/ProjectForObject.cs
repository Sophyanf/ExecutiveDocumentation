
namespace ExecutiveDocumentation.Models
{
    public class ProjectForObject : IDataObject
    {
        public int ID { get; set; }
        public string Shifr { get; set; }

        // Только латиница
        public Kontragent ProjectCompany { get; set; }

        // Просто поле. Никаких [ForeignKey], никаких [Required]
        public int ConstructionObjectId { get; set; }

        // Навигация. virtual нужен для ленивой загрузки
        public ConstructionObject ConstructionObject { get; set; }

        public override string ToString()
        {
            var companyName = ProjectCompany?.KontragentShortName ?? "(без компании)";
            return $"{Shifr} ({companyName})";
        }
    }
}