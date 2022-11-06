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
    public class GetJobEmploymentTypesQueryHandler : IRequestHandler<GetJobEmploymentTypesQuery, List<RCMEmploymentTypeDTO>>
    {
        private readonly IDataBaseContext<RCMEmploymentType> _context;

        public GetJobEmploymentTypesQueryHandler(IDataBaseContext<RCMEmploymentType> context)
        {
            _context = context;
        }

        public async Task<List<RCMEmploymentTypeDTO>> Handle(GetJobEmploymentTypesQuery request, CancellationToken cancellationToken)
        {
            var employmentTypes = await _context.List();

            return employmentTypes.Select(x => new RCMEmploymentTypeDTO() { EmploymentTypeId = x.Id, EmploymentTypeName = x.EmploymentTypeName }).ToList();
        }
    }
}
