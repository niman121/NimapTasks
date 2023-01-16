using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Services
{
    public class CustomFilter : ActionFilterAttribute  
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.Controller.ViewBag.Result = "Filter on Result Executing";
            base.OnResultExecuting(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Controller.ViewBag.Action = "Filter on Action Executed";
            base.OnActionExecuting(context);
        }
    }

    public class CustomExceptionFilter : FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.ViewBag.Exception = "EROROROROROROROROROROROROROARARARARARARARRARARARROROROROROROR";
            filterContext.Exception.Message.Insert(1,"EROROROROROROROROROROROROROARARARARARARARRARARARROROROROROROR");
            

        }
    }
}