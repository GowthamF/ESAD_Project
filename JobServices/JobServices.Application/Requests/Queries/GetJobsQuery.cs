using JobServices.Application.DTOs;
using JobServices.Application.Requests.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries
{
    public class GetJobsQuery : IRequest<List<GetJobResponseModel>>
    {
        public bool IsArchived
        {
            get; set;
        }
    }
}
