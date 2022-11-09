using JobServices.Application.DTOs;
using JobServices.Application.Requests.Commands.RequestModel;
using JobServices.Application.Requests.Commands.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.Application.Requests.Commands
{
    public class UpdateJobCommand : IRequest<UpdateJobCommandResponseModel>
    {
        public UpdateJobCommandRequestModel? RCMJob
        {
            get; set;
        }
    }
}
