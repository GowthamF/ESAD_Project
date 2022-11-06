using JobServices.Application.DTOs;
using JobServices.Application.Requests.Commands;
using JobServices.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobServices.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RCMEmploymentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RCMEmploymentTypeController(IMediator mediator)
        {
            _mediator= mediator;
        }


        [HttpGet("GetEmploymentTypes")]
        public async  Task<List<RCMEmploymentTypeDTO>> GetRCMEmploymentTypes()
        {
            return await _mediator.Send(new GetJobEmploymentTypesQuery());
        }

        [HttpGet("GetRCMEmploymentTypeById/{employmentTypeId}")]
        public async Task<RCMEmploymentTypeDTO> GetRCMEmploymentTypeById(int employmentTypeId)
        {
            return await _mediator.Send(new GetJobEmploymentTypeByIdQuery() { EmploymentTypeId = employmentTypeId});
        }

        [HttpPost("CreateEmploymentType")]
        public async Task<RCMEmploymentTypeDTO> CreateEmploymentType([FromBody] string employmentTypeName)
        {
            return await _mediator.Send(new CreateJobEmploymentTypeCommand() { EmploymentTypeName = employmentTypeName});
        }

        [HttpPut("UpdateEmploymentType")]
        public async Task<RCMEmploymentTypeDTO> UpdateEmploymentType([FromBody] RCMEmploymentTypeDTO employmentType)
        {
            return await _mediator.Send(new UpdateJobEmploymentTypeCommand() { EmploymentType = employmentType });
        }

        [HttpDelete("DeleteEmploymentType/{employmentTypeId}")]
        public async Task<int> DeleteEmploymentType(int employmentTypeId)
        {
            return await _mediator.Send(new DeleteJobEmploymentTypeCommand() { EmploymentTypeId = employmentTypeId });
        }

    }
}
