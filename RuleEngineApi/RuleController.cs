using Microsoft.AspNetCore.Mvc;
using RuleEngineContract;
using System.Threading.Tasks;

namespace RuleEngineApi
{
    [ApiController]
    [Route("rule")]
    public class RuleController : ControllerBase
    {
        private readonly IProcessRulesManager _processRulesManager;


        public RuleController(IProcessRulesManager processRulesManager)
        {
            _processRulesManager = processRulesManager;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentRule>> ApplyRule(PaymenteModel values)
        {

            var completedJob = await _processRulesManager.ProcessAsync(values);

            return Created("Applied Rules", completedJob);
        }
    }
}
