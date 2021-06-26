using RuleEngineContract;
using System;
using System.Collections.Generic;

namespace RuleEngineContract
{
    public class PaymentRule 
    {
        public string PaymentType { get; set; }
        public string Events { get; set; }
    }
    public class PaymentAction
    {
        public string ActionCode { get; set; }
        public string Action { get; set; }
    }
}
