using DashboardMatab.Models;
using DashboardMatab.Models.Entities;
using DashboardMatab.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace DashboardMatab.Services
{

    public class Repository
    {
        private readonly MatabDBEntities db;

        public Repository(MatabDBEntities _db)
        {
            db = _db;
        }
       
        public List<TblParvande> getParvande(TblParvande tblParvande)
        {

            //if (tblParvande.Fname is null) tblParvande.Fname = "";
            //if (tblParvande.Lname is null) tblParvande.Lname = "";
            //if (tblParvande.Mobile is null) tblParvande.Mobile = "";


            long? ParvandeCodeC = tblParvande.ParvandeCode;

            //var data = (from p in db.TblParvande
            //            where (tblParvande.Lname != null ? tblParvande.Lname.Contains(p.Lname) : 1 == 1) &&
            //                  (tblParvande.Fname != null ? tblParvande.Fname.Contains(p.Fname) : 1 == 1) &&
            //                  (tblParvande.Mobile != null ? tblParvande.Mobile.Contains(p.Mobile) : 1 == 1) &&
            //                  (tblParvande.MelliCode != null ? p.MelliCode.Equals(tblParvande.MelliCode) : 1 == 1)
            //            select p).ToList().Where(x => x.ParvandeCode.Equals(ParvandeCodeC)).ToList();

            var data = db.TblParvande
                .Where(f =>
                f.Lname.Contains(tblParvande.Lname) ||
                f.Fname.Contains(tblParvande.Fname) ||
                f.Mobile.Contains(tblParvande.Mobile) ||
                f.MelliCode.Contains(tblParvande.MelliCode)

            ).ToList();




            return data;
        }

        public TblParvande ParvandeById(int id)
        {
            return db.TblParvande.Where(f => f.ParvandeID == id).FirstOrDefault();
        }
        public Matab_PMH GetMatab_PMH(int ParvarndeCode)
        {
            return db.Matab_PMH.Where(f => f.ParvandeCode == ParvarndeCode).FirstOrDefault();
        }
        public Matab_Visit_ViewModel GetMatab_Visit(int ParvarndeCode)
        {
            var data = db.Matab_Visit.Where(f => f.ParvandeCode == ParvarndeCode).Select(f=>new Matab_Visit_ViewModel() { 
            
                Diagnose=f.Diagnose,
                Diastolic=f.Diastolic,
                DocID=f.DocID,
                DrugDesc=f.DrugDesc,
                DrugDose=f.DrugDose,
                Head=f.Head,
                Hight=f.Hight,
                ID=f.ID,
                ParvandeCode=f.ParvandeCode,
                PatientsComplaints=f.PatientsComplaints,
                PresentIllness=f.PresentIllness,
                Systolic=f.Systolic,
                VisitDate=f.VisitDate,
                VisitPlan=f.VisitPlan,
                Weight=f.Weight
            
            }) .FirstOrDefault() ;

            return data;
        }
        public List<ViewMatab_LabTests> GetViewMatab_LabTests(int ParvarndeCode)
        {
            List<ViewMatab_LabTests> data = new List<ViewMatab_LabTests>();

            var Get = db.Matab_LabTests.Where(f => f.ParvandeCode == ParvarndeCode).ToList();

            foreach (var item in Get)
            {
                ViewMatab_LabTests v = new ViewMatab_LabTests()
                {
                    //ID=item.ID,
                    LabDate = item.LabDate,
                    LabResult = item.LabResult,
                    //LabResultDate=item.LabResultDate,
                    //MaxRange=item.MaxRange,
                    //MinRange=item.MinRange,
                    //ParvandeCode=item.ParvandeCode,
                    RangeComment = item.RangeComment,
                    //TestCode=item.TestCode,
                    TestName = db.TblLabTests.Where(f => f.TestCode == item.TestCode).FirstOrDefault().TestFullName
                };
                data.Add(v);
            }



            return data;
        }
        public List<ViewMatab_VisitDrug> GetMatab_VisitDrugs(long ParvandeCode)
        {

            List<ViewMatab_VisitDrug> data = new List<ViewMatab_VisitDrug>();
            var Get = db.Matab_VisitDrug.Where(f => f.Matab_Visit.ParvandeCode == ParvandeCode).ToList();

            foreach (var item in Get)
            {
                ViewMatab_VisitDrug d = new ViewMatab_VisitDrug()
                {

                    Number = item.Number,
                    VisitDate = item.Matab_Visit.VisitDate
                };
                if (item.DrugID != null)
                {
                    d.DrugName = db.TblDrugs.Where(f => f.DrgID == item.DrugID).FirstOrDefault().BrandName;
                }
                if (item.DrugOrderID != null)
                {
                    d.DrugOrderText = db.tbl_DrugOrder.Where(f => f.num == item.DrugOrderID).FirstOrDefault().Order;

                }

                data.Add(d);
            }

            return data;


        }
        public string ConvertDateToPersian(DateTime dt)
        {
            DateTime d = dt;
            PersianCalendar pc = new PersianCalendar();
            return (string.Format("{0}/{1}/{2} {3}:{4}:{5}.{6}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), pc.GetHour(d), pc.GetMinute(d), pc.GetSecond(d), pc.GetMilliseconds(d)));
        }

        public int GetAge(string burnDateYear)
        {
            int bY = Int32.Parse(burnDateYear.Substring(0, 4));
            DateTime d = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            var year = (string.Format("{0}", pc.GetYear(d)));

            return (Int32.Parse(year) - bY);
        }

    }
}