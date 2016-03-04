using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.LocalStorageService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.LocalStorageService
{
    public static class LocalCache
    {
        private static Dictionary<string, object> Items = new Dictionary<string, object>();

        public static SubagentCachingData OwnSubagentCachingData { get; set; }

        public static List<TransactionPurpose> GetTransactionPurposeList()
        {
            string key = "TransactionPurpose";
            if (Items.Keys.Contains(key))
            {
                return (List<TransactionPurpose>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetTransactionPurposeList());
                return (List<TransactionPurpose>)Items[key];
            }
        }

        public static List<Occupation> GetOccupations()
        {
            string key = "Occupation";
            if (Items.Keys.Contains(key))
            {
                return (List<Occupation>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetOccupations());
                return (List<Occupation>)Items[key];
            }
        }

        public static List<Country> GetCountries()
        {
            string key = "Country";
            if (Items.Keys.Contains(key))
            {
                return (List<Country>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetCountries());
                return (List<Country>)Items[key];
            }
        }

        public static List<Division> GetDivisions()
        {
            string key = "Division";
            if (Items.Keys.Contains(key))
            {
                return (List<Division>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetDivisions());
                return (List<Division>)Items[key];
            }
        }

        public static List<District> GetDistricts()
        {
            string key = "Districts";
            if (Items.Keys.Contains(key))
            {
                return (List<District>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetDistricts());
                return (List<District>)Items[key];
            }
        }

        public static List<District> GetDistrictsByDivisionID(int divisionId)
        {
            string key = "Districts" + divisionId.ToString();
            if (Items.Keys.Contains(key))
            {
                return (List<District>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                //Items.Add(key, localStorage.GetDistricts().Where(district => district.division.id == divisionId));
                Items.Add(key, localStorage.GetDistrictsByDivisionID(divisionId));
                return (List<District>)Items[key];
            }
        }

        public static List<Thana> GetThanasByDistrictID(long districtId)
        {
            string key = "Thanas" + districtId.ToString();
            if (Items.Keys.Contains(key))
            {
                return (List<Thana>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetThanasByDistrictID(districtId));
                return (List<Thana>)Items[key];
            }
        }

        public static List<PostalCode> GetPostalCodesByDistrictID(long districtId)
        {
            string key = "PostalCodes" + districtId.ToString();
            if (Items.Keys.Contains(key))
            {
                return (List<PostalCode>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetPostalCodesByDistrictID(districtId));
                return (List<PostalCode>)Items[key];
            }
        }

        public static List<TermProductType> GetITDProducts()
        {
            string key = "TermProductTypeITD";
            if (Items.Keys.Contains(key))
            {
                return (List<TermProductType>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetITDProducts());
                return (List<TermProductType>)Items[key];
            }
        }

        public static List<TermProductType> GetMTDProducts()
        {
            string key = "TermProductTypeMTD";
            if (Items.Keys.Contains(key))
            {
                return (List<TermProductType>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetMTDProducts());
                return (List<TermProductType>)Items[key];
            }
        }

        public static List<AgentProduct> GetDepositProducts()
        {
            string key = "DepositProductType";
            if (Items.Keys.Contains(key))
            {
                return (List<AgentProduct>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetDepositProducts());
                return (List<AgentProduct>)Items[key];
            }
        }

        public static List<SspInstallment> GetITDInstallment()
        {
            string key = "SspInstallment";
            if (Items.Keys.Contains(key))
            {
                return (List<SspInstallment>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetITDInstallment());
                return (List<SspInstallment>)Items[key];
            }
        }

        public static List<ExchangeHouse> GetExchangeHouses()
        {
            string key = "ExchangeHouse";
            if (Items.Keys.Contains(key))
            {
                return (List<ExchangeHouse>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetExchangeHouses());
                return (List<ExchangeHouse>)Items[key];
            }
        }

        public static List<SectorCodeInfo> GetSectorCodes()
        {
            string key = "SectorCode";
            if (Items.Keys.Contains(key))
            {
                return (List<SectorCodeInfo>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetSectorCodes());
                return (List<SectorCodeInfo>)Items[key];
            }
        }

        public static List<CisInstituteType> GetCisInstituteTypes()
        {
            string key = "CisInstituteType";
            if (Items.Keys.Contains(key))
            {
                return (List<CisInstituteType>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetCisInstituteTypes());
                return (List<CisInstituteType>)Items[key];
            }
        }

        public static List<CisType> GetCisTypes()
        {
            string key = "CisType";
            if (Items.Keys.Contains(key))
            {
                return (List<CisType>)Items[key];
            }
            else
            {
                LocalStorage localStorage = new LocalStorage();
                Items.Add(key, localStorage.GetCisTypes());
                return (List<CisType>)Items[key];
            }
        }


    }
}