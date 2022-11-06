using JobServices.Application.DTOs;
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


        [HttpGet]
        public async  Task<List<RCMEmploymentTypeDTO>> GetRCMEmploymentTypes()
        {
            return await _mediator.Send(new GetJobEmploymentTypesQuery());
        }
    }
}
