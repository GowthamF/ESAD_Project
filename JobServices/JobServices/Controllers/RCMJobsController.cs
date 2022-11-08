using JobServices.Application.DTOs;
using JobServices.Application.Requests.Commands;
using JobServices.Application.Requests.Queries;
using JobServices.Application.Requests.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobServices.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RCMJobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RCMJobsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetJobs/{isArchived}")]
        public async Task<List<GetJobResponseModel>> GetJobs(bool isArchived)
        {
            return await _mediator.Send(new GetJobsQuery() { IsArchived = isArchived});
        }

        [HttpGet("GetJobById/{jobId}")]
        public async Task<GetJobResponseModel> GetJobById(int jobId)
        {
            return await _mediator.Send(new GetJobByIdQuery() { JobId = jobId });
        }

        [HttpPost("CreateJob")]
        public async Task<RCMJobDTO> CreateJob([FromBody] RCMJobDTO job)
        {
            return await _mediator.Send(new CreateJobCommand() {    Job = job });
        }

        [HttpPut("UpdateJob")]
        public async Task<RCMJobDTO> UpdateJob([FromBody] RCMJobDTO job)
        {
            return await _mediator.Send(new UpdateJobCommand() { RCMJob = job });
        }

        [HttpDelete("DeleteJob/{jobId}")]
        public async Task<int> DeleteJob(int jobId)
        {
            return await _mediator.Send(new DeleteJobCommand() { JobId = jobId });
        }
    }
}
