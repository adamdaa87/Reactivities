using System;
using MediatR;
using Domain; // Assuming Activity is in Domain namespace
using Persistence;
using Microsoft.EntityFrameworkCore; // for FindAsync, ToListAsync

namespace Application.Activities.Queries
{
    public class GetActivityDetails
    {
        // Query to get the details of a specific activity by ID
        public class Query : IRequest<Activity>
        {
            public required string Id { get; set; }
        }

        // Handler definition
        public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Id], cancellationToken);
                
                if (activity == null) throw new Exception("Activity not found");

                return activity;
            }
        }
    }
}