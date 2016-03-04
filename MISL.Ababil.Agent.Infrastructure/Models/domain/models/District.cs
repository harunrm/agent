using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models
{
    public class District
    {
        private static long serialVersionUID = 1L;
        public int id { get; set; }
        public string title { get; set; }
        public Division division { get; set; }

        //private long id;

        //private string title;

        //private Division division;

        //public long getId()
        //{
        //    return id;
        //}
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public string getTitle()
        //{
        //    return title;
        //}
        //public void setTitle(string title)
        //{
        //    this.title = title;
        //}
        //public Division getDivision()
        //{
        //    return division;
        //}
        //public void setDivision(Division division)
        //{
        //    this.division = division;
        //}
    }
}
