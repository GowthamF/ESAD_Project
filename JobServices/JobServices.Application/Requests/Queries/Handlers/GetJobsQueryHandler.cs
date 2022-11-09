using JobServices.Application.DTOs;
using JobServices.Application.Requests.Queries.ResponseModel;
using JobServices.BusinessEntities.Interfaces;
using JobServices.BusinessEntities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries.Handlers
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, List<GetJobResponseModel>>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public GetJobsQueryHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }

        public async Task<List<GetJobResponseModel>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.List(x=>x.IsArchived == request.IsArchived);

            return jobs.Select(job => new GetJobResponseModel() { Id = job.Id, JobName = job.JobName, Status = "OPEN", Candidates = 0, HiringManagers = new List<string>() { "Admin" ,"Admin1"}, PostingDate = job.PublishedDate.Date.ToString("yyyy-MM-dd"),JobDescription = job.JobDescription, IsArchived = job.IsArchived, ClosingDate = job.ClosingDate.Date.ToString("yyyy-MM-dd"), IsPublic = job.IsPublic }).ToList();
        }
    }
}
