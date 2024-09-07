using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Filters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;
             if (shirt == null) 
             {
                context.ModelState.AddModelError("Shirt","Srhit object is null");

                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status= StatusCodes.Status400BadRequest
                };
                context.Result=new BadRequestObjectResult(problemDetails);
             }
             else
             {
                var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color,shirt.Size);
               
                if (existingShirt != null)
                {
                     context.ModelState.AddModelError("Shirt","Shirt alreay exist");

                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status= StatusCodes.Status400BadRequest
                };
                context.Result=new BadRequestObjectResult(problemDetails);
                }

             }

        }

    }
}