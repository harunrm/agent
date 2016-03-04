using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Behavior;

namespace MISL.Ababil.Agent.Services
{
    public class UpdateService
    {
        public static UpdateType CheckUpdateType ()
        {
            UpdateType updateType = UpdateType.None;
            if (UpdateCom.IsUpdateaAvailable())
            {
                updateType = UpdateType.Normal;
                if (UpdateCom.IsUpdateForced())
                {
                    updateType = UpdateType.Enforced;
                }
            }
            return updateType;
        }


        public static bool InitiateUpdate(ISoftwareUpdateObserver observer)
        {
            if (observer == null) return false;
            UpdateCom.ClearUpdateObservers();
            UpdateCom.RegisterUpdateObserver(observer);
            return UpdateCom.InitiateUpdate();
        }

        

    }

    public enum UpdateType
    {
        Normal,
        Enforced,
        None
    }
}