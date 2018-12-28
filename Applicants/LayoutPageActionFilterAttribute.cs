using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Applicants.Data;

namespace Applicants
{
    public class LayoutPageActionFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var mgr = new ApplicantRepository(Properties.Settings.Default.ConStr);
            filterContext.Controller.ViewBag.ApplicantCounts = mgr.GetCounts();
            base.OnActionExecuting(filterContext);
        }
    }
}