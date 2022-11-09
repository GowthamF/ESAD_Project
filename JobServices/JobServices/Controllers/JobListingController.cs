using JobServices.Application.Requests.Queries;
using JobServices.Application.Requests.Queries.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobServices.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobListingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetPublicJobs")]
        public async Task<List<GetJobListingResponseModel>> GetPublicJobs()
        {
            return await _mediator.Send(new GetJobListingQuery() { IsPublic = true });
        }

        [HttpGet("GetInternalJobs")]
        public async Task<List<GetJobListingResponseModel>> GetInternalJobs()
        {
            return await _mediator.Send(new GetJobListingQuery() { IsPublic = false });
        }
    }
}
