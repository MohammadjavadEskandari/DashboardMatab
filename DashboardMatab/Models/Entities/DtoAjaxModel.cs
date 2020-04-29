using DashboardMatab.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashboardMatab.Models.Entities
{
    public class DtoAjaxModel
    {
        public TblParvande TblParvande { get; set; }
        public Matab_PMH Matab_PMH { get; set; }
        public Matab_Visit_ViewModel Matab_Visit { get; set; }
        public List<ViewMatab_LabTests> ViewMatab_LabTests { get; set; } 
        public List<ViewMatab_VisitDrug> matab_VisitDrugs { get; set; }

    }
}