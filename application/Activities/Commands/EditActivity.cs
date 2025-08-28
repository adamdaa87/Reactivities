using System.Diagnostics;
using Domain;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using AutoMapper;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Domain.Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);
            if (activity == null)
            {
                throw new Exception("Cannot find Activity");
            }

            // Update only the properties that are not null in the incoming activity
            mapper.Map(request.Activity, activity);

            try
            {
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw; // Re-throw the exception after logging it
            }
        }
    } 
}