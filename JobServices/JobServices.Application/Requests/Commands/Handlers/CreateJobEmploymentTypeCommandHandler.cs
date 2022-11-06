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
    public class CreateJobEmploymentTypeCommandHandler : IRequestHandler<CreateJobEmploymentTypeCommand, RCMEmploymentTypeDTO>
    {
        private readonly IDataBaseContext<RCMEmploymentType> _context;

        public CreateJobEmploymentTypeCommandHandler(IDataBaseContext<RCMEmploymentType> context)
        {
            _context = context;
        }

        public async Task<RCMEmploymentTypeDTO> Handle(CreateJobEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            if (request.EmploymentTypeName == null)
            {
                throw new Exception("Employment Type Name is required");
            }
            var employmentType = new RCMEmploymentType() { EmploymentTypeName = request.EmploymentTypeName };

            await _context.Create(employmentType);

            return new RCMEmploymentTypeDTO() { EmploymentTypeName = employmentType.EmploymentTypeName, EmploymentTypeId = employmentType.Id };
        }
    }
}
