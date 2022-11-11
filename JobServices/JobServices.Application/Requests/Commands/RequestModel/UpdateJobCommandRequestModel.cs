using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Commands.RequestModel
{
    public class UpdateJobCommandRequestModel
    {
        public int Id
        {
            get; set;
        }

        public string JobName
        {
            get; set;
        }

        public string JobDescription
        {
            get; set;
        }

        public DateTimeOffset PublishedDate
        {
            get; set;
        }

        public bool IsPublic
        {
            get; set;
        }

        public bool IsArchived
        {
            get; set;
        }

        public DateTimeOffset ClosingDate
        {
            get; set;
        }

        public int EmploymentTypeId
        {
            get; set;
        }
    }
}
