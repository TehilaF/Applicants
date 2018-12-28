using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Applicants.Data
{
    public class ApplicantRepository
    {
        private string _connectionstring;
        public ApplicantRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Add(Applicant applicant)
        {
            using (var context = new Applicants_DataDataContext(_connectionstring))
            {
                context.Applicants.InsertOnSubmit(applicant);
                context.SubmitChanges();
            }
        }

        public IEnumerable<Applicant> GetApplicants(Status status)
        {
            using (var context = new Applicants_DataDataContext(_connectionstring))
            {
                return context.Applicants.Where(a => a.Status == status).ToList();
            }
        }

        public Applicant GetApplicant(int id)
        {
            using (var context = new Applicants_DataDataContext(_connectionstring))
            {
                return context.Applicants.FirstOrDefault(a => a.Id == id);
            }
        }

        public void UpdateStatus(int id, Status status)
        {
            using(var context = new Applicants_DataDataContext(_connectionstring))
            {
                context.ExecuteCommand("UPDATE Applicants SET Status = {0} WHERE Id = {1}", status, id);
            }
        }

        public ApplicantCounts GetCounts()
        {
            using (var context = new Applicants_DataDataContext(_connectionstring))
            {
                return new ApplicantCounts
                {
                    Confirmed = context.Applicants.Count(a => a.Status == Status.Confirmed),
                    Pending = context.Applicants.Count(a => a.Status == Status.Pending),
                    Refused = context.Applicants.Count(a => a.Status == Status.Refused)
                };
            }
        }
    }
}
