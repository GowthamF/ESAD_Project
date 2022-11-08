using JobServices.Application.DTOs;
using JobServices.BusinessEntities.Interfaces;
using JobServices.BusinessEntities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Commands.Handlers
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, RCMJobDTO>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public CreateJobCommandHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }

        public async Task<RCMJobDTO> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            if (request.Job == null)
            {
                throw new Exception("Job Name is required");
            }
            var job = new RCMJobs() 
            { 
                JobName = request.Job.JobName,
                AddedBy = "Gowtham",
                AddedOn = DateTimeOffset.Now,
                IsArchived = false,
                IsPublic = true,
                JobDescription = request.Job.JobDescription,
                PublishedDate = DateTimeOffset.Now,
            };

            await _context.Create(job);

            return new RCMJobDTO() { JobName = job.JobName };
        }
    }
}
