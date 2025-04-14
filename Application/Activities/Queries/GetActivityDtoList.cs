using System;
using System.Diagnostics;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Activities.Dtos;

namespace Application.Activities.Queries;

// public class GetActivityDtoList
// {
//     //Get the list of activities.  Get a list of DTOs for Opportunity.
//     public class Query : IRequest<List<ActivityDto>>  {}
//     public class Handler(AppDbContext context) : IRequestHandler<Query, List<ActivityDto>>
//     {
//         public async Task<List<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
//         {
//             //Get a list of activities. The DTO should be less data.
//             return await context.ActivityDto.ToListAsync();
//         }
//     }
// }