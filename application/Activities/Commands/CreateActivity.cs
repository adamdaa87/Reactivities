using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {
        // Command to create a new activity
        public class Command : IRequest<string>
        {
            public required Activity Activity { get; set; }
        }

        // Handler definitionstring
        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);
                await context.SaveChangesAsync(cancellationToken);
                return request.Activity.Id; // Return the ID of the created activity
            } 
        }
    }
}