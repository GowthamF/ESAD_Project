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
    public class GetJobEmploymentTypeByIdQueryHandler : IRequestHandler<GetJobEmploymentTypeByIdQuery, RCMEmploymentTypeDTO>
    {
        private readonly IDataBaseContext<RCMEmploymentType> _context;

        public GetJobEmploymentTypeByIdQueryHandler(IDataBaseContext<RCMEmploymentType> context)
        {
            _context = context;
        }

        public async Task<RCMEmploymentTypeDTO> Handle(GetJobEmploymentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var employmentType = await _context.GetById(request.EmploymentTypeId);

            if (employmentType == null)
            {
                throw new Exception("No Employment Type found for this ID " + request.EmploymentTypeId);
            }
            return new RCMEmploymentTypeDTO() { EmploymentTypeId = employmentType.Id, EmploymentTypeName = employmentType.EmploymentTypeName };
        }
    }
}
