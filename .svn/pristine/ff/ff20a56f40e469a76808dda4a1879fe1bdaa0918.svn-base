using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.LocalStorageService.Communication;
using MISL.Ababil.Agent.LocalStorageService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.LocalStorageService.Services
{
    public class SubagentUserService
    {
        public SubagentCachingData GetSubagentCachingData(string subagentUser)
        {
            SubagentUserCom subagentUserCom = new SubagentUserCom();
            SubagentCachingData subagentCachingData = subagentUserCom.GetSubagentCachingData(subagentUser);
            return subagentCachingData;
        }

        //public static ServiceResult GetRemittanceList(string subagentUser)
        //{
        //    var serviceResult = ServiceResult.CreateServiceResult();
        //    serviceResult.ReturnedObject = "";
        //    try
        //    {
        //        SubagentUserCom subagentUserCom = new SubagentUserCom();
        //        serviceResult.ReturnedObject = subagentUserCom.GetSubagentCachingData(subagentUser);
        //        if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
        //        {
        //            serviceResult.ReturnedObject = "";
        //            serviceResult.Message = "error msg";
        //        }
        //        else
        //        {
        //            serviceResult.Success = true;
        //            serviceResult.Message = serviceResult.ReturnedObject.ToString();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        serviceResult.Message = exception.Message;
        //    }
        //    return serviceResult;
        //}
    }
}