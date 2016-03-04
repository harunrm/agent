using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;

namespace MISL.Ababil.Agent.Infrastructure.Behavior
{
    public interface ITransactionProfileUpdateObserver
    {
        void ProfileSetUpdated(CbsTxnProfileSet profileSet);
 
    }
}