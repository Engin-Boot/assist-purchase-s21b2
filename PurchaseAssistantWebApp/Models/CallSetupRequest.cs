﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PurchaseAssistantWebApp.Models
{
    public class CallSetupRequest
    {
        [Key]
        public string RequestId { get; set; }

        public string CoustomerName { get; set; }       // considerinig it as userName for time being.

        //public string CousterId { get; set; }

        public string Organisation { get; set; }

        public string Region { get; set; }

        public string Email { get; set; }

        // This property will store list of strings as "ProductName ProductKey" e.g. "IntelliVue X3"
        public IEnumerable<string> SelectedModels { get; set; }
    }
}
