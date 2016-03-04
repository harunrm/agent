using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
namespace MISL.Ababil.Agent.Services
{
    public class CustomerServices
    {
        CustomerCom objCustomerCom = new CustomerCom();

        //======================================================================================================//

        public static List<CustomerInfoDto> getAllCustomerInfoList(CustomerSearchDto dto)
        {
            List<CustomerInfoDto> customerInfo = new List<CustomerInfoDto>();
            CustomerCom customerCom = new CustomerCom();
            customerInfo = customerCom.getAllListOfCustomer(dto);
            return customerInfo;
        }

        //=========================================================================================================//
        public string saveCustomerAccDTO(CustomerAccountDto customerAccountDto)
        {
            var json = JsonConvert.SerializeObject(customerAccountDto); //new JavaScriptSerializer().Serialize(customerAccountDto);
            return objCustomerCom.saveCustomerAccDTO(json);
        }
        public string saveCustomer(CustomerInformation customerInformation)
        {
            var json = JsonConvert.SerializeObject(customerInformation); //new JavaScriptSerializer().Serialize(customerInformation);
            return objCustomerCom.saveCustomer(json);
        }
        public CustomerAccountDto GetCustomerAccountDtoByAcc(string accNo)
        {
            return objCustomerCom.GetCustomerAccountDtoByAcc(accNo);
        }
        public CustomerInformation GetCustomerInfoByConsumerAppId(long ConsumerAppId)
        {
            return objCustomerCom.GetCustomerInfoByConsumerAppId(ConsumerAppId);
        }

        public CustomerInformation GetCustomerInfoByCustomerId(long CustomerId)
        {
            return objCustomerCom.GetCustomerInfoByCustomerId(CustomerId);
        }
        public CustomerDto GetCustomerInfo(int customerId)
        {
            return objCustomerCom.getCustomerInfo(customerId);
        }


        
    }
}
