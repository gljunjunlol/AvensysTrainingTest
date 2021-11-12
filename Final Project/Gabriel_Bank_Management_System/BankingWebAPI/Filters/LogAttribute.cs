using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BankingWebAPI.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            Trace.WriteLine("WebAPI Logs (Log): " + actionContext.ActionDescriptor.ActionName + " gets executed at " + DateTime.Now.ToString("HH:mm:ss"));
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            Trace.WriteLine("WebAPI Logs (Log): " + actionExecutedContext.ActionContext.ActionDescriptor.ActionName + " finished execution at " + DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}