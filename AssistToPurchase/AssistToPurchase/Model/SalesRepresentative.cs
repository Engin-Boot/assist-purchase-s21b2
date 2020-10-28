using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
