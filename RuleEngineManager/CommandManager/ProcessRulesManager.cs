using AutoMapper;
using RuleEngineContract;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RuleEngineManager
{
    public class ProcessRulesManager : IProcessRulesManager
    {
        private readonly ILogger<ProcessRulesManager> _logger;
        private readonly IRulesRepository _repository;
        public ProcessRulesManager(ILogger<ProcessRulesManager> logger, IRulesRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<PaymenteModel> ProcessAsync(PaymenteModel job)
        {
            try
            {
                var rules= await _repository.GetRules();
                var actions = await _repository.GetActions();


                job.Action = rules.Where(s => s.PaymentType == job.PaymentType)?.FirstOrDefault()?.Events;

                //perform actions
                await RaiseEventsAsync(job, actions);

                return job;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        private static async Task<PaymenteModel> RaiseEventsAsync(PaymenteModel job,List<PaymentAction> actions)
        {
            try
            {

                var events = job.Action.Split('-');


                //perform actions
                foreach (var ev in events)
                {
                    if (actions.Where(s=>s.Action.Trim()==ev.Trim()).FirstOrDefault()?.ActionCode== "DuplicatePackingSlip")
                    {
                        //generating packaging slip
                    }
                    if (actions.Where(s => s.Action.Trim() == ev.Trim()).FirstOrDefault().ActionCode == "GenerateCommission")
                    {
                        //generate commission to agent
                    }
                }


                return job;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
