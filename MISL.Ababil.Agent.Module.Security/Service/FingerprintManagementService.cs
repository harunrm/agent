using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Module.Security.Models;
using MISL.Ababil.Agent.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Module.Security.Service
{
    public class FingerprintManagementService
    {
        public BioDataChangeReqDto GetBioDataChangeReqDtoList(string accountNumber, string referenceNumber)
        {
            WebClientCommunicator<object, BioDataChangeReqDto> webClientCommunicator = new WebClientCommunicator<object, BioDataChangeReqDto>();

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                return webClientCommunicator.GetResult(null, "resources/biodatachange/reqdto/" + accountNumber);
            }
            else
            {
                return webClientCommunicator.GetResult(null, "resources/biodatachange/reqdto/" + accountNumber + "/" + referenceNumber);
            }
        }

        public string UpdateBioDataChangeReqDtoList(BioDataChangeReqDto _bioDataChangeReqDto)
        {
            WebClientCommunicator<BioDataChangeReqDto, string> webClientCommunicator = new WebClientCommunicator<BioDataChangeReqDto, string>();
            string retVal = webClientCommunicator.GetPostResult(_bioDataChangeReqDto, "resources/biodatachange/request");
            return "Request successfully sent. Reference No. : " + retVal;
        }

        public List<BioDataChangeReqSearchResultDto> GetBioDataChangeReqSearchDtoList(BioDataChangeReqSearchDto _bioDataChangeReqSearchDto)
        {
            WebClientCommunicator<BioDataChangeReqSearchDto, List<BioDataChangeReqSearchResultDto>> webClientCommunicator = new WebClientCommunicator<BioDataChangeReqSearchDto, List<BioDataChangeReqSearchResultDto>>();
            return webClientCommunicator.GetPostResult(_bioDataChangeReqSearchDto, "resources/biodatachange/search");
        }

        public string SubmitTokens(BioDataChangeReqDto _bioDataChangeReqSearchDto)
        {
            WebClientCommunicator<BioDataChangeReqDto, string> webClientCommunicator = new WebClientCommunicator<BioDataChangeReqDto, string>();
            return webClientCommunicator.GetPostResult(_bioDataChangeReqSearchDto, "resources/biodatachange/accept");
        }

        public void ResendToken(BioChangeDto bioChangeDto)
        {
            WebClientCommunicator<BioChangeDto, object> webClientCommunicator = new WebClientCommunicator<BioChangeDto, object>();
            webClientCommunicator.GetPostResult(bioChangeDto, "resources/biodatachange/rsendtoken/identity");
        }

        public string Reject(string id)
        {
            WebClientCommunicator<object, string> webClientCommunicator = new WebClientCommunicator<object, string>();
            return webClientCommunicator.GetResult("resources/biodatachange/cancel/" + id);
        }
    }
}