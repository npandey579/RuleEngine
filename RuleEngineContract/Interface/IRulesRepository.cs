
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineContract
{
    public interface IRulesRepository
    {
        public  Task<List<PaymentRule>> GetRules();
        public Task<List<PaymentAction>> GetActions();

    }
}
