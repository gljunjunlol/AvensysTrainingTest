using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BankingWebAPI.Filters
{
    public class LogActionAttribute : Attribute, IActionFilter  // Iactionfilter add logic before action method gets executed
                                                                // can use other filters too
    {
        public bool AllowMultiple => true;  // action filter to override

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine("WebAPI Logs: " + actionContext.ActionDescriptor.ActionName + " gets executed at " + DateTime.Now.ToString("HH:mm:ss")); Task<HttpResponseMessage> result = continuation();  // continuation = delegate here
            result.Wait();
            Trace.WriteLine("WebAPI Logs: " + actionContext.ActionDescriptor.ActionName + " finished execution at " + DateTime.Now.ToString("HH:mm:ss"));
            return result;
        }
    }
}