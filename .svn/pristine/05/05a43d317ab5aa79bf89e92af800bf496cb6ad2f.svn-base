using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MISL.Ababil.Agent.Module.Common.Service
{
    public class CommentService
    {
        public ServiceResult GetCommentsID(string CommentId)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = new List<CommentDto>();

            try
            {
                serviceResult.ReturnedObject = GetCommentsByID(CommentId);
                if (serviceResult.ReturnedObject == null)
                {
                    serviceResult.ReturnedObject = new List<CommentDto>();
                    serviceResult.Message = "msg";
                }
                else
                {
                    serviceResult.Success = true;
                }
            }
            catch (Exception exception)
            {
                serviceResult.Message = exception.Message;
            }

            return serviceResult;
        }

        public List<CommentDto> GetCommentsByID(string commentId)
        {
            List<CommentDto> listData = new List<CommentDto>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/comment/allcomment/" + commentId;
            try
            {
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<CommentDto>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}