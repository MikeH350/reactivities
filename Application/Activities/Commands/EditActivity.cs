using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands

public class EditActivity
{
    public class Command : IRequest
    {
        public required Domain.Activity Activity {get; set;}
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);
            if (activity == null) throw new Exception ("Cannot find activity");
        
            activity.Title = request.Activity.Title;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    
    }
}

}