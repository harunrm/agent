﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis
{
    public class CisOwnerType
    {

        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string description { get; set; }
        public string ownerCode { get; set; }
        public CisType cisType { get; set; }


        //public long getId()
        //{
        //    return id;
        //}
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public string getDescription()
        //{
        //    return description;
        //}
        //public void setDescription(string description)
        //{
        //    this.description = description;
        //}
        //public string getOwnerCode()
        //{
        //    return ownerCode;
        //}
        //public void setOwnerCode(string ownerCode)
        //{
        //    this.ownerCode = ownerCode;
        //}

    }
}
