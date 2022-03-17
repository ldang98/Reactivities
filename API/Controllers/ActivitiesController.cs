using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;
namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        

        [HttpGet]
        //get list of activities
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            //mediator obj will send request to the handler in Application layer
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        //ApiController attribute is smart enough to know to look for 
        //the activity to be added in the body of the request
        public async Task<IActionResult> CreateActivity(Activity activity){
                                                            //{} c# object initializer
            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity){
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id){
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}