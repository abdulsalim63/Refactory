using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Merchant.Application.Models.Query;
using Merchant.Application.UseCases.Merchants;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Merchant.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MerchantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseDto<MerchantInput>>> Post([FromBody] BaseRequest<MerchantInput> payload)
        {
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<MerchantInput>>> Get()
        {
            return Ok(await _mediator.Send(new GetMerchantsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<MerchantInput>>> GetbyId(int Id)
        {
            return Ok(await _mediator.Send(new GetMerchantQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<MerchantInput>>> PutbyId(int Id, [FromBody] BaseRequest<MerchantInput> payload)
        {
            return Ok(await _mediator.Send(new UpdateMerchantCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<MerchantInput>>> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeleteMerchantCommand() { id = Id }));
        }
    }
}
