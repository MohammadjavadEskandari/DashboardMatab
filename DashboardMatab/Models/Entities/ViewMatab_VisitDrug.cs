using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashboardMatab.Models.Entities
{
    public class ViewMatab_VisitDrug
    {

        public string VisitDate { get; set; }
        public string DrugName { get; set; }
        public int? Number { get; set; }
        public string DrugOrderText { get; set; }


    }
}