using System.Collections.Generic;

namespace DashboardMatab.Models.Entities
{
    public class DtoModel
    {
        //public DashboardMatab.Models.TblParvande Matab_PMH { get; set; }
        public TblParvande TblParvande { get; set; }
        public List<TblParvande> listTblParvande { get; set; }

    }
}