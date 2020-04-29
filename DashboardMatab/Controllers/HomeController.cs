using DashboardMatab.Models;
using DashboardMatab.Models.Entities;
using DashboardMatab.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashboardMatab.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository ser;

        public HomeController(Repository _ser)
        {
            ser = _ser;
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string _Name, string _Pass)
        {

            if (_Name == "Admin" && _Pass == "123")
            {
                HttpContext.Session["login"] = "1";
                return RedirectToAction("Index");

            }

            HttpContext.Session["login"] = "0";
            ViewBag.Error = "نام کاربری و رمز عبور اشتباه می باشد";
            return View();
        }
        public ActionResult Index()
        {
            if (HttpContext.Session["login"] == null || HttpContext.Session["login"] == "0")
            {
                return RedirectToAction("Login");
            }

            DtoModel d = new DtoModel();
            d.TblParvande = new DashboardMatab.Models.TblParvande();
            d.listTblParvande = new List<TblParvande>();
            return View(d);
        }

        [HttpPost]
        public ActionResult Index(DtoModel dtoModel)
        {
            var data = ser.getParvande(dtoModel.TblParvande);
            DtoModel d = new DtoModel();
            d.TblParvande = dtoModel.TblParvande;
            d.listTblParvande = data;
            return View(d);
        }

        [HttpPost]
        public string GetParvandeById(int DataJson)
        {
            DtoAjaxModel data = new DtoAjaxModel();
            data.TblParvande = ser.ParvandeById(DataJson);
            data.TblParvande.Age = ser.GetAge(data.TblParvande.BurnDate);
            data.Matab_PMH = ser.GetMatab_PMH(DataJson);
            data.Matab_Visit = ser.GetMatab_Visit(DataJson);
            if (data.Matab_Visit != null)
            {
                data.matab_VisitDrugs = ser.GetMatab_VisitDrugs(DataJson);
            }
            data.ViewMatab_LabTests = ser.GetViewMatab_LabTests(DataJson);
            string dataJson = JsonConvert.SerializeObject(data);
            return dataJson;
        }


    }
}