namespace wepAPI.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;
        public TimeMiddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            }

            if (!context.Response.HasStarted)
            {
                await next.Invoke(context);
            }
            

        }


    }

    public static class TimeMiddlewareExtention
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}


