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
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers
{
    [AllowAnonymous]
    public class ActivitiesController : BaseApiController
    {
        

        [HttpGet]
        //get list of activities
        public async Task<IActionResult> GetActivities(){
            //mediator obj will send request to the handler in Application layer
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id){
            var result = await Mediator.Send(new Details.Query{Id = id});
            return HandleResult(result);
        }

        [HttpPost]
        //ApiController attribute is smart enough to know to look for 
        //the activity to be added in the body of the request
        public async Task<IActionResult> CreateActivity(Activity activity){
                                                            //{} c# object initializer
            return HandleResult(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity){
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id){
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}