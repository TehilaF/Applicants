using Applicants.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Applicants.Models;


namespace Applicants.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Page = PageType.Home;
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Page = PageType.Add;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Applicant applicant)
        {
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            mgr.Add(applicant);
            return Redirect("/home/index");
        }

        public ActionResult Pending()
        {
            ViewBag.Page = PageType.Pending;
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            return View(new ApplicantsViewModel { Applicants = mgr.GetApplicants(Status.Pending) });
        }

        public ActionResult Details(int id)
        {
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            return View(new ApplicantViewModel { Applicant = mgr.GetApplicant(id) });
        }

        [HttpPost]
        public void UpdateStatus(int id, Status status)
        {
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            mgr.UpdateStatus(id, status);
        }

        public ActionResult GetCounts()
        {
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            return Json(mgr.GetCounts(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Confirmed()
        {
            ViewBag.Page = PageType.Confirmed;
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            return View(new ApplicantsViewModel
            {
                Applicants = mgr.GetApplicants(Status.Confirmed)
            });
        }
        public ActionResult Refused()
        {
            ViewBag.Page = PageType.Refused;
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            return View(new ApplicantsViewModel { Applicants = mgr.GetApplicants(Status.Refused) });
        }
    }
}