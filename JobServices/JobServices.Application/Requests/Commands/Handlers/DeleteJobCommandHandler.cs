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
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, int>
    {
        private readonly IDataBaseContext<RCMJobs> _context;

        public DeleteJobCommandHandler(IDataBaseContext<RCMJobs> context)
        {
            _context = context;
        }


        public async Task<int> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = new RCMJobs() { Id = request.JobId};
            var response = await _context.Delete(job);

            return response.Id;
        }
    }
}
