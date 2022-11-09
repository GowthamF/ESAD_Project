using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries.ResponseModel
{
    public class GetJobListingResponseModel
    {
        public int JobId
        {
            get; set;
        }

        public string JobTitle
        {
            get; set;
        }

        public string JobDescription
        {
            get; set;
        }

        public string ClosingDate
        {
            get; set;
        }
    }
}
