using System;
using System.Collections.Generic;

namespace RuleEngineContract
{
    public class PaymentRuleModel
    {
        public PaymentRuleModel()
        {
            Events = new List<string>();
        }

        public PaymentType PaymentType { get; set; }
        public List<string> Events { get; set; }
    }
}
