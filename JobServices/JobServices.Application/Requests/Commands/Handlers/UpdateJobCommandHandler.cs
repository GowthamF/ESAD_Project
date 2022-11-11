using JobServices.Application.DTOs;
using JobServices.Application.Requests.Commands.ResponseModel;
using JobServices.BusinessEntities.Interfaces;
using JobServices.BusinessEntities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Commands.Handlers
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, UpdateJobCommandResponseModel>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public UpdateJobCommandHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }


        public async Task<UpdateJobCommandResponseModel> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            if (request.RCMJob == null)
            {
                throw new Exception("Employment Type is required");
            }

            var existingEntity = await _context.GetById(request.RCMJob.Id);

            if (existingEntity != null)
            {
                existingEntity.IsArchived = request.RCMJob.IsArchived;

                if (existingEntity.IsArchived)
                {
                    existingEntity.ArchiveDate = DateTimeOffset.Now;
                }
                else
                {
                    existingEntity.ArchiveDate = null;
                }

                existingEntity.IsPublic = request.RCMJob.IsPublic;
                existingEntity.JobDescription = request.RCMJob.JobDescription;
                existingEntity.JobName = request.RCMJob.JobName;
                existingEntity.ClosingDate = request.RCMJob.ClosingDate;
                existingEntity.RCMEmploymentTypeId = request.RCMJob.EmploymentTypeId;
                    
                var entity = await _context.Update(existingEntity);
            }

            return new UpdateJobCommandResponseModel();
        }
    }
}
