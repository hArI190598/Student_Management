using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StudentManagement.Middleware
{
    public class ResponseTimeMiddleware
    {
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        private readonly RequestDelegate _next;
        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext Context)
        {
            var watch = new Stopwatch();
            watch.Start();
            Context.Response.OnStarting(() =>
            {
                // Stop the timer information and calculate the time
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.
                Context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                return Task.CompletedTask;
            });
                 // Call the next delegate/middleware in the pipeline
                   return this._next(Context);
        }
    }
    
}
