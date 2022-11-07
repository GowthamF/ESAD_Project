using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries.Responses
{
    public class GetJobResponseModel
    {
        public int Id
        {
            get; set;
        }

        public string JobName
        {
            get; set;
        }

        public int Candidates
        {
            get; set;
        }

        public string PostingDate
        {
            get; set;
        }

        public List<string> HiringManagers
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }
    }
}
