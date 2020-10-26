using System.ComponentModel.DataAnnotations;

namespace PurchaseAssistantWebApp.Models
{
    public class SalesRepresentative
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string DepartmentRegion { get; set; }

        public string Email { get; set; }

    }
}
