using System;
using System.Net;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using System.Collections.Generic;

namespace MISL.Ababil.Agent.Communication
{
    public class UserCom
    {

        public string CreateBranchUser(string branchUserJson)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/security/user/create";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", branchUserJson);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                return responseString;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }
        public List<OutletUserInfoReportResultDto> GetOutletUserInformation(string outletid)
        {

            List<OutletUserInfoReportResultDto> Data = new List<OutletUserInfoReportResultDto>();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/userinfo/outletusers/" + outletid;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<List<OutletUserInfoReportResultDto>>(responseString);
                    return Data;
                }

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        //public List<OutletUserInfoReportResultDto> GetOutletUserInformation(string outletid)
        //{
        //    List<OutletUserInfoReportResultDto> Data = new List<OutletUserInfoReportResultDto>();
        //    WebClient client = new WebClient();
        //    try
        //    {
        //        String path = SessionInfo.rootServiceUrl + "resources/userinfo/outletusers/" + outletid;
        //        client = UtilityCom.setClientHeaders(client);
        //        string responseString = client.DownloadString(path);
        //        string responseStatusCode;
        //        string responseStatusDescription;
        //        JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
        //        if (responseStatusCode == HttpStatusCode.NotFound.ToString())
        //            return null;
        //        else
        //        {
        //            Data = JsonConvert.DeserializeObject<List<OutletUserInfoReportResultDto>>(responseString);
        //            return Data;
        //        }

        //    }
        //    catch (WebException webEx)
        //    {
        //        throw new Exception(UtilityCom.parseErrorData(webEx));
        //    }
        //}
    }

}