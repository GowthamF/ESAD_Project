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
    public class UpdateJobEmploymentTypeCommandHandler : IRequestHandler<UpdateJobEmploymentTypeCommand, RCMEmploymentTypeDTO>
    {
        private readonly IDataBaseContext<RCMEmploymentType> _context;

        public UpdateJobEmploymentTypeCommandHandler(IDataBaseContext<RCMEmploymentType> context)
        {
            _context = context;
        }


        public async Task<RCMEmploymentTypeDTO> Handle(UpdateJobEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            if (request.EmploymentType == null)
            {
                throw new Exception("Employment Type is required");
            }
            
            var entity = await _context.Update(new RCMEmploymentType() { EmploymentTypeName = request.EmploymentType.EmploymentTypeName, Id = request.EmploymentType.EmploymentTypeId });

            return new RCMEmploymentTypeDTO() { EmploymentTypeId = entity.Id,EmploymentTypeName = entity.EmploymentTypeName };
        }
    }
}
