using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Needed for ToListAsync
using Persistence;
using System.Diagnostics;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {

        // GET: api/activities
        [HttpGet]
        public async Task<ActionResult<List<Activity>>>GetActivities()
        {
            return Ok(await context.Activities.ToListAsync());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Activity>>> GetActivityDetail(string id)
        {
            var activity = await context.Activities.FindAsync(id);
            
            if (activity == null) return NotFound();

            return Ok(activity);
        }
    }
}
