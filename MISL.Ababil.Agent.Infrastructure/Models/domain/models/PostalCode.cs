using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models
{
    public class PostalCode
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string area { get; set; }
        public string postalCode { get; set; }
        public District district { get; set; }
        
        //private long id;
        //private string area;
        //private string postalCode;

        //private District district;
        //public long getId()
        //{
        //    return id;
        //}
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public string getArea()
        //{
        //    return area;
        //}
        //public void setArea(string area)
        //{
        //    this.area = area;
        //}
        //public District getDistrict()
        //{
        //    return district;
        //}
        //public void setDistrict(District district)
        //{
        //    this.district = district;
        //}
        //public string getPostalCode()
        //{
        //    return postalCode;
        //}
        //public void setPostalCode(string postalCode)
        //{
        //    this.postalCode = postalCode;
        //}

    }
}
