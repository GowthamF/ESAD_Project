using JobServices.Application.Requests.Queries.ResponseModel;
using JobServices.BusinessEntities.Interfaces;
using JobServices.BusinessEntities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries.Handlers
{
    public class GetJobListingQueryHandler : IRequestHandler<GetJobListingQuery, List<GetJobListingResponseModel>>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public GetJobListingQueryHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }

        public async Task<List<GetJobListingResponseModel>> Handle(GetJobListingQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.List(x => x.IsPublic == request.IsPublic && !x.IsArchived);

            return jobs.Select(job => new GetJobListingResponseModel() { JobId = job.Id, JobTitle = job.JobName, JobDescription = job.JobDescription, ClosingDate= job.ClosingDate.Date.ToString("yyyy-MM-dd") }).ToList();
        }
    }
}
