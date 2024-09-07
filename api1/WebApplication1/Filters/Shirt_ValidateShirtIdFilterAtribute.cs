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
    public class Shirt_ValidateShirtIdFilterAtribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId=context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId","ShirtId is invalid");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                            Status=StatusCodes.Status400BadRequest
                    };
                    context.Result=new BadRequestObjectResult(problemDetail);   
                }

               else if (!ShirtRepository.ShirtExists(shirtId.Value))
                {
                    context.ModelState.AddModelError("ShirtId","ShirtId doesnt exists");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                            Status=StatusCodes.Status404NotFound
                    };
                    context.Result=new NotFoundObjectResult(problemDetail);   
                }
                
            }
        }
    }
}