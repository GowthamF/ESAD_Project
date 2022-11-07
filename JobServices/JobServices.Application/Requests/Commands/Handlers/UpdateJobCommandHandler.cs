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

namespace JobServices.Application.Requests.Commands.Handlers
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, RCMJobDTO>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public UpdateJobCommandHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }


        public async Task<RCMJobDTO> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            if (request.RCMJob == null)
            {
                throw new Exception("Employment Type is required");
            }
            
            var entity = await _context.Update(new RCMJobs() { JobName = request.RCMJob.JobName, Id= request.RCMJob.Id});

            return new RCMJobDTO() {  };
        }
    }
}
