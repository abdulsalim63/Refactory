﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Notification.Application.UseCases.Notifications;

namespace Notification.Presenter.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNotificationCommand payload)
        {
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string include)
        {
            var Include = include ?? "None";
            return Ok(await _mediator.Send(new GetNotificationsQuery() { include = Include }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetbyId(int Id, string include)
        {
            var Include = include ?? "None"; 
            return Ok(await _mediator.Send(new GetNotificationQuery() { id = Id, include = Include }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateNotificationCommand payload)
        {
            return Ok(await _mediator.Send(new UpdateNotificationCommand() {
                id = Id,
                data = payload.data
            }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeleteNotificationCommand() { id = Id }));
        }
    }
}
