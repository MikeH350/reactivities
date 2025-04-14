using System;
using Application.Activities.Dtos;
using Application.Activities.Queries;
using Application.Activities.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController: BaseApiController
{
    [HttpGet] //get the data
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query{Id = id});
    }
    // [HttpGet("dto")]
    // public async Task<ActionResult<List<ActivityDto>>> GetActivitiesDto()
    // {
    //     return await mediator.Send(new GetActivityDtoList.Query());
    // }
    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command{Activity = activity});
    }

    // [HttpPut]
    // public async Task<ActionResult> EditActivity(Activity activity)
    // {
    //     return await Mediator.Send(new EditActivity.Command{Activity = activity});
    // }

}