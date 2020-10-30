using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistToPurchase.Model
{
    class CallSetupRequest
    {
        public string RequestId { get; set; }//

        public string CoustomerName { get; set; }

        public string Organisation { get; set; }

        public string Region { get; set; }

        public string Email { get; set; }

        // This property will store list of strings as "ProductName ProductKey" e.g. "IntelliVue X3"
        public IEnumerable<string> SelectedModels { get; set; }
    }
}
