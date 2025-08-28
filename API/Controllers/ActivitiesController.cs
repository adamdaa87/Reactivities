using System;
using Application.Activities.Queries;
using Domain; // Assuming Activity is in Domain namespace
using MediatR;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Activities.Commands; // Needed for ToListAsync

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        // GET: api/activities
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Command { Activity = activity });
        }

        [HttpPut]
        public async Task<IActionResult> EditActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command { Activity = activity });
            return NoContent();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id });
            return Ok();
        }        
    }
}
