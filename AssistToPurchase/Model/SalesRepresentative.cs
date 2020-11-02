using System.Runtime.Serialization;

namespace AssistToPurchase.Model
{
    [DataContract]
    class SalesRepresentative
    {
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
