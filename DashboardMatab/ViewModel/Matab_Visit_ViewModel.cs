using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashboardMatab.ViewModel
{
    public class Matab_Visit_ViewModel
    {
        public long ID { get; set; }
        public string VisitDate { get; set; }
        public long? ParvandeCode { get; set; }
        public string PatientsComplaints { get; set; }
        public string PresentIllness { get; set; }
        public string VisitPlan { get; set; }
        public string Diagnose { get; set; }
        public double? Weight { get; set; }
        public double? Hight { get; set; }
        public double? Head { get; set; }
        public double? Systolic { get; set; }
        public double? Diastolic { get; set; }
        public double? DrugDose { get; set; }
        public int? DocID { get; set; }
        public string DrugDesc { get; set; }
    }
}