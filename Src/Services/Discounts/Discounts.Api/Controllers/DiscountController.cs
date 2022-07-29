using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discounts.Services.Coupons.Commands.Create;
using Discounts.Services.Coupons.Commands.Delete;
using Discounts.Services.Coupons.Commands.Update;
using Discounts.Services.Coupons.Queries.GetAll;
using Discounts.Services.Coupons.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Discounts.Api.Controllers
{
    public class DiscountController : Controller
    {
        IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDiscount()
        {
            return Ok(await _mediator.Send(new GetAllCouponQuery()));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetCouponByIdQuery() {Id=id }));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddDiscount(AddCouponCommand addCouponCommand)
        {
            return Ok(await _mediator.Send(addCouponCommand));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponCommand updateCouponCommand)
        {
            return Ok(await _mediator.Send(updateCouponCommand));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCoupon(DeleteCouponCommand deleteCouponCommand)
        {
            return Ok(await _mediator.Send(deleteCouponCommand));
        }
    }
}
