using System;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class DeleteActivity
    {
        public class Command : IRequest
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Id], cancellationToken)
                    ?? throw new Exception("Connot find Activity");

                context.Remove(activity);
                var success = await context.SaveChangesAsync(cancellationToken) > 0;
                if (!success) throw new Exception("Problem saving changes");
                return;
            }

        }    
    }
}