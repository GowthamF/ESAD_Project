using JobServices.Application.DTOs;
using JobServices.Application.Requests.Commands.RequestModel;
using JobServices.Application.Requests.Commands.ResponseModel;
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
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, CreateJobCommandResponseModel>
    {
        private readonly IDataBaseContext<RCMJobs> _context;
        private readonly IDataBaseContext<RCMEmploymentType> _employmentTypecontext;

        public CreateJobCommandHandler(IDataBaseContext<RCMJobs> context , IDataBaseContext<RCMEmploymentType> dataBaseContext)
        {
            _context = context;
            _employmentTypecontext = dataBaseContext;
        }

        public async Task<CreateJobCommandResponseModel> Handle(CreateJobCommand request, CancellationToken cancellationToken)
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
                ClosingDate = request.Job.ClosingDate,
                RCMEmploymentTypeId = request.Job.EmploymentTypeId
            };

            await _context.Create(job);

            return new CreateJobCommandResponseModel() { JobName = job.JobName };
        }
    }
}
