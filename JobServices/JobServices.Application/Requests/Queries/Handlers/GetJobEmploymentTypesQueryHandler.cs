using JobServices.Application.DTOs;
using JobServices.BusinessEntities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Queries.Handlers
{
    public class GetJobEmploymentTypesQueryHandler : RequestHandler<GetJobEmploymentTypesQuery, List<RCMEmploymentTypeDTO>>
    {
        private readonly DataBaseContext _context;

        public GetJobEmploymentTypesQueryHandler(DataBaseContext context)
        {
            _context = context;
        }

        protected override List<RCMEmploymentTypeDTO> Handle(GetJobEmploymentTypesQuery request)
        {
            return _context.RCMEmploymentTypes
                .ToList()
                .Select(x => new RCMEmploymentTypeDTO() 
                { EmploymentTypeId = x.Id, EmploymentTypeName = x.EmploymentTypeName })
                .ToList();
        }
    }
}
