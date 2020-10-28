using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace PurchaseAssistantWebApp.Models
{
    [DataContract]
    public class SalesRepresentative
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DepartmentRegion { get; set; }
        [DataMember]
        public string Email { get; set; }

    }
}
