using MediatR;
using Domain; // or your actual namespace for Activity
using Persistence; // if you need to access the DbContext
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Queries
{
    public class GetActivityList
    {
        // Query to get the list of activities 
        // Query definition
        public class Query : IRequest<List<Activity>>{}

        // Handler definition
        public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
        {
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Activities.ToListAsync(cancellationToken); 
            }
        }
    }    
}