using System;
using System.Diagnostics;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Activities.Queries;

public class GetActivityList
{
    //Get the list of activities.  Get a list of DTOs for Opportunity.
    public class Query : IRequest<List<Domain.Activity>>  {}
    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Domain.Activity>>
    {
        public async Task<List<Domain.Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            //Get a list of activities. The DTO should be less data.
            return await context.Activities.ToListAsync();
        }
    }
}