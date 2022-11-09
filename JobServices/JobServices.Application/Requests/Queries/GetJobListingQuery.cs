using JobServices.Application.DTOs;
using JobServices.Application.Requests.Queries.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries
{
    public class GetJobListingQuery : IRequest<List<GetJobListingResponseModel>>
    {
        public bool IsPublic
        {
            get; set;
        }
    }
}
