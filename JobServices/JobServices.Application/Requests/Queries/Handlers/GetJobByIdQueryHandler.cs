using JobServices.Application.DTOs;
using JobServices.Application.Requests.Queries.Responses;
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
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, GetJobResponseModel>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public GetJobByIdQueryHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }

        public async Task<GetJobResponseModel> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _context.GetById(request.JobId);

            if (job == null)
            {
                throw new Exception("No Job found for this ID " + request.JobId);
            }
            return new GetJobResponseModel() { Id = job.Id, JobName = job.JobName, Status = "OPEN", Candidates = 0, HiringManagers = new List<string>(), PostingDate = job.PublishedDate.Date.ToString("dd-MM-yyyy"), JobDescription = job.JobDescription };
        }
    }
}
