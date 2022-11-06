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
    public class DeleteJobEmploymentTypeCommandHandler : IRequestHandler<DeleteJobEmploymentTypeCommand, int>
    {
        private readonly IDataBaseContext<RCMEmploymentType> _context;

        public DeleteJobEmploymentTypeCommandHandler(IDataBaseContext<RCMEmploymentType> context)
        {
            _context = context;
        }


        public async Task<int> Handle(DeleteJobEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            var employmentType = new RCMEmploymentType() { Id = request.EmploymentTypeId};
            var response = await _context.Delete(employmentType);

            return response.Id;
        }
    }
}
