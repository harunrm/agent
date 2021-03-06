﻿using System.Security.Cryptography.X509Certificates;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;

namespace MISL.Ababil.Agent.Infrastructure.Behavior
{
    public interface IProfileUpdateObserver
    {
        void ProfileUpdated(KycProfile profile);
    }
}