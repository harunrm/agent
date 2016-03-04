using System;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using System.Collections.Generic;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.Services
{
    public class UserService
    {
        UserCom userCom = new UserCom();
        public static ServiceResult CreateBranchUser(BranchUser user)
        {
            ServiceResult serviceResult = new ServiceResult();
            UserCom userCom = new UserCom();
            string json = JsonConvert.SerializeObject(user); //new JavaScriptSerializer().Serialize(user);
            string responseString;
            serviceResult.Success = false;
            try
            {
                responseString = userCom.CreateBranchUser(json);
                serviceResult.Message = responseString;
                serviceResult.Success = true;
            }
            catch (Exception ex)
            {
                serviceResult.Message = ex.Message;
                //throw;
            }
            return serviceResult;
        }

        public List<OutletUserInfoReportResultDto> GetUserBasicInformation(string outletid)
        {
            return userCom.GetOutletUserInformation(outletid);
        }

        //public List<OutletUserInfoReportResultDto> GetUserBasicInformation(string outletid, UserStatus userStatus)
        //{
        //    return userCom.GetOutletUserInformation(outletid, userStatus);
        //}
    }
}