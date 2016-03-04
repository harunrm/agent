using MISL.Ababil.Agent.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.Threading.Tasks;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Services
{
    public class LoginService
    {
        LoginCom loginCom = new LoginCom();
        AgentCom objAgent = new AgentCom();


        public Boolean RequiresBiometricAuthentication(string username)
        {
            SessionInfo.rootServiceUrl = ConfigurationManager.AppSettings["servicerooturl"].ToString();
            string type = loginCom.GetAuthenticationType(username);
            if (type == "BIOMETRIC")
            {
                return true;
            }
            else if (type == "BASIC")
            {
                return false;
            }
            else
            {
                throw new Exception("Cannot determine authentication level.");
            }
        }


        public Boolean authenticate(string username, string password, Boolean fingerPrintApplicable, string bioTemplate)
        {

            UserLoginData userLoginData = new UserLoginData();
            //userLoginData=loginCom.authenticate(username, password, bioTemplate);
            string serviceLoginURL;

            string servicerooturl = UtilityServices.getConfigData("servicerooturl");
            string terminal = getLocalIP();
            bool isexpired = false;

            // string fingerPrintApplicable = UtilityServices.getConfigData("fingerPrintApplicable");

            try
            {
                if (fingerPrintApplicable)
                {
                    if (bioTemplate != "")
                    {
                        serviceLoginURL = UtilityServices.getConfigData("loginurlWithFingerprint");
                        userLoginData = loginCom.getUserRigtsWithFingerData(username, password, getLocalIP(), bioTemplate, serviceLoginURL);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    serviceLoginURL = UtilityServices.getConfigData("loginurlWithoutFingerprint");
                    userLoginData = loginCom.getUserRigtsWithoutFingerprint(username, password, terminal, serviceLoginURL);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



            if (userLoginData == null)
            {
                return false;
            }
            if (userLoginData.token != "")
            {
                SessionInfo.isexpired = userLoginData.isexpired;
                SessionInfo.token = userLoginData.token;
                SessionInfo.rights = userLoginData.rights;
                SessionInfo.roles = userLoginData.roles;
                SessionInfo.loginTime =  DateTime.Now;
                SessionInfo.username = username;
                SessionInfo.rootServiceUrl = servicerooturl;
                SessionInfo.terminal = terminal;
                //__change when service is available__//
                SessionInfo.currentDate = DateTime.Now;
                //

                Task task = new Task(new Action(SetUserBasicInfo));
                task.Start();

                return true;
            }
            else
                return false;
        }

        public static void SetUserBasicInfo()
        {
            try
            {
                LoginService loginService = new LoginService();
                UserBasicInformation userBasicInformation = new UserBasicInformation();
                UserBasicInformationDto userBasicInformationDto = loginService.GetUserBasicInformation(SessionInfo.username);
                userBasicInformation.userType = userBasicInformationDto.userType;

                if(userBasicInformationDto.currentDate.ToString("dd/MM/YYYY")!= DateTime.Now.ToString("dd/MM/YYYY"))
                {
                    MessageBox.Show("Server date and client date is not same! Please sync the date and log-in again.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SessionInfo.currentDate = userBasicInformationDto.currentDate;

                if (userBasicInformationDto.outlet != null)
                {
                    userBasicInformation.division = userBasicInformationDto.outlet.businessAddress.division;
                    userBasicInformation.district = userBasicInformationDto.outlet.businessAddress.district;
                    userBasicInformation.thana = userBasicInformationDto.outlet.businessAddress.thana;
                    SubAgentInformation subAgentInformation = new SubAgentInformation();
                    subAgentInformation.id = userBasicInformationDto.outlet.id;
                    subAgentInformation.name = userBasicInformationDto.outlet.name;
                    subAgentInformation.businessAddress = userBasicInformationDto.outlet.businessAddress;
                    userBasicInformation.postalCode = userBasicInformationDto.outlet.businessAddress.postalCode;
                    userBasicInformation.outlet = subAgentInformation;
                }


                if (userBasicInformationDto.outlet != null || userBasicInformationDto.agent != null)
                {

                    AgentInformation agentInformation = new AgentInformation();
                    agentInformation.id = userBasicInformationDto.agent.id;
                    agentInformation.businessName = userBasicInformationDto.agent.businessName;
                    agentInformation.agentCode = userBasicInformationDto.agent.agentCode;
                    userBasicInformation.agent = agentInformation;
                }

                SessionInfo.userBasicInformation = userBasicInformation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string getTokenNumber(string username, string password)
        {
            string serviceLoginURL = ConfigurationManager.AppSettings["serviceloginurl"].ToString();
            string tokenNumber = loginCom.getTokenNumber(username, password, getLocalIP(), serviceLoginURL);
            if (tokenNumber == "10060" || tokenNumber == "10061")
                return "failed";
            else if (tokenNumber == "404")
            {
                return "notfound";
            }
            else
            {

                SessionInfo.username = username;
                SessionInfo.token = tokenNumber;
                SessionInfo.rootServiceUrl = ConfigurationManager.AppSettings["servicerooturl"].ToString();
                //ConnectionHeaders connHd = new ConnectionHeaders { Username = ConnHeaders.username, Token = ConnHeaders.token, terminal = getLocalIP() };

                /// LoggedUserRights.token = tokenNumber;
                //LoggedUserRights.rights = UserWiseRights.BranchRights;

                return "success";
            }
        }
        public string getLoginDataWithoutFingerprint(string username, string password)
        {

            string serviceLoginURL = ConfigurationManager.AppSettings["loginurlWithoutFingerprint"].ToString();

            UserLoginData objUserRights = new UserLoginData();
            //objUserRights = new UserLoginData { rights = new List<string> { Rights.DRAFT_CONSUMER_APPLICATION.ToString() }, token = "hg56hgfhd7887vhggffg" };
            objUserRights = loginCom.getUserRigtsWithoutFingerprint(username, password, getLocalIP(), serviceLoginURL);

            if (objUserRights == null)
                return "failed";
            else
            {

                SessionInfo.username = username;
                SessionInfo.token = objUserRights.token;
                SessionInfo.rootServiceUrl = ConfigurationManager.AppSettings["servicerooturl"].ToString();

                SessionInfo.token = objUserRights.token;
                SessionInfo.rights = objUserRights.rights;
                SessionInfo.roles = objUserRights.roles;
                return "success";
            }





        }
        public string getLoginDataWithFingerprint(string username, string password, string bioTemplate)
        {
            string serviceLoginURL = ConfigurationManager.AppSettings["loginurlWithFingerprint"].ToString();
            UserLoginData objUserRights = new UserLoginData();
            objUserRights = loginCom.getUserRigtsWithFingerData(username, password, getLocalIP(), bioTemplate, serviceLoginURL);

            //temp
            //if (objUserRights != null)
            //{
            //    objUserRights = new UserLoginData();
            //    objUserRights.token = "uriuerew";
            //    //List<string> rits = new List<string>(new string[] { Rights.DRAFT_CONSUMER_APPLICATION.ToString(), Rights.SUBMIT_CONSUMER.ToString(), Rights.CANCEL_CONSUMER_APPLICATION.ToString() });
            //    objUserRights.rights = UserWiseRights.fieldOfficerRights;
            //}
            //end temp


            if (objUserRights == null)
                return "failed";
            else
            {

                SessionInfo.username = username;
                SessionInfo.token = objUserRights.token;
                SessionInfo.rootServiceUrl = ConfigurationManager.AppSettings["servicerooturl"].ToString();

                SessionInfo.token = objUserRights.token;
                SessionInfo.rights = objUserRights.rights;
                SessionInfo.roles = objUserRights.roles;
                return "success";
            }
        }
        private string getLocalIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public UserBasicInformationDto GetUserBasicInformation(string userName)
        {
            return loginCom.GetUserBasicInformation(userName);
        }
    }
}
