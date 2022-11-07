using JobServices.Application.DTOs;
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
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, List<RCMJobDTO>>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public GetJobsQueryHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }

        public async Task<List<RCMJobDTO>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.List();

            return jobs.Select(x => new RCMJobDTO() { Id = x.Id, JobName = x.JobName }).ToList();
        }
    }
}
