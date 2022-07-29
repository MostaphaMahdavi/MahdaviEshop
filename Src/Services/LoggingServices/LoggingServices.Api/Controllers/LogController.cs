using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingServices.Domains.Loggings.Dtos;
using LoggingServices.Domains.Loggings.Entities;
using LoggingServices.Domains.Loggings.Repositories;
using LoggingServices.Services.Loggings.Commands.Delete;
using LoggingServices.Services.Loggings.Queries.Get;
using LoggingServices.Services.Loggings.Queries.GetAll;
using MahdaviEshop.Framework.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LoggingServices.Api.Controllers
{
    public class LogController : BaseController
    {
        IMediator _mediator;
        public LogController(IMediator mediator)
        {
            _mediator = mediator;
          
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
           var logs= await _mediator.Send(new GetAllLodDataQuery());
            return Ok(logs);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var log = await _mediator.Send(new GetLogByIdQuery {Id=id });
            if (log is null)
                return NotFound();   
            return Ok(log);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(LogDataInfo newLogData)
        {
            var LogDataDto = LogData.Create(newLogData.ControllerName,newLogData.ActionName,newLogData.LogLevel,newLogData.Message);
            await _mediator.Send(newLogData);
            return CreatedAtAction(nameof(Get), new { id = LogDataDto.Id }, newLogData);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Put(UpdateLogDataInfo updatelogData)
        {
            var log = await _mediator.Send(new GetLogByIdQuery { Id=updatelogData.Id});
            if (log is null)
                return NotFound();   
           await _mediator.Send(updatelogData);
            return Ok();
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
            var log = await _mediator.Send(new GetLogByIdQuery() { Id=id});
            if (log is null)
                return NotFound();
            await _mediator.Send(new DeleteLogCommand() { Id=id});
            return Ok();
        }
    }
}

