using JobServices.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Commands
{
    public class UpdateJobEmploymentTypeCommand : IRequest<RCMEmploymentTypeDTO>
    {
        public RCMEmploymentTypeDTO? EmploymentType
        {
            get; set;
        }
    }
}
