using System.Threading.Tasks;

namespace RuleEngineContract
{
    public interface IProcessRulesManager
    {
        Task<PaymenteModel> ProcessAsync(PaymenteModel rule);
    }
}