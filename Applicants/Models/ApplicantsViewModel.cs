using Applicants.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Applicants.Models
{
    public class ApplicantsViewModel
    {
        public IEnumerable<Applicant> Applicants { get; set; }
    }
}