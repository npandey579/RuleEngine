using Newtonsoft.Json.Linq;
using RuleEngineContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineData
{
    public class RulesRepository : IRulesRepository
    {
        public RulesRepository() 
        {

        }
        public async Task<List<PaymentRule>> GetRules()
        {
            var json = await File.ReadAllTextAsync("Rules.json");
            try
            {
                List<PaymentRule> rules = new List<PaymentRule>();
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {

                    JArray paymentRules = (JArray)jObject["PaymentRules"];
                    if (paymentRules != null)
                    {
                        foreach (var item in paymentRules)
                        {
                            PaymentRule rule = new PaymentRule();

                            rule.PaymentType = item["PaymentType"].ToString();
                            rule.Events=item["Event"].ToString();
                            rules.Add(rule);
                        }

                    }
                    

                }
                return rules;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<PaymentAction>> GetActions()
        {
            var json = await File.ReadAllTextAsync("Rules.json");
            try
            {
                List<PaymentAction> actions = new List<PaymentAction>();
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {

                    JArray paymentActions = (JArray)jObject["Actions"];
                    if (paymentActions != null)
                    {
                        foreach (var item in paymentActions)
                        {
                            PaymentAction action = new PaymentAction();

                            action.Action = item["Action"].ToString();
                            action.ActionCode = item["ActionCode"].ToString();
                            actions.Add(action);
                        }

                    }


                }
                return actions;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
