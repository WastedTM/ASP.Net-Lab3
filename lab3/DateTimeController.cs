using Microsoft.AspNetCore.Mvc;

namespace lab3;

public class DateTimeController
{
        public IDateTimeService PeriodController { get; }
        public DateTimeController(IDateTimeService period)
        {
            PeriodController = period;
        }
}

public class Middleware
{
    RequestDelegate next;
    int i = 0;

    public Middleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IDateTimeService date, DateTimeController dateController)
    {
        if (httpContext.Request.Path == "/")
        {
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync("Enter '/task1' or '/task2'");
        }

        if (httpContext.Request.Path == "/task1")
        {
            var calcService = httpContext.RequestServices.GetService<ICalcMethod>();
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Test add number: {calcService?.AddNumbers(1, 2, 3, 55)}" +
                                                  $"\nTest subtract number: {calcService?.SubtractNumbers(100, 1, 2, 3, 55)}" +
                                                  $"\nTest multiply number: {calcService?.MultiplicationNumbers(2, 3, 9)}" +
                                                  $"\nTest division number: {calcService?.DivisionNumbers(55.55, 11.11)}");
        }

        if (httpContext.Request.Path == "/task2")
        {
            i++;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Request {i}; DateTimeService: {date.Period}; DateTimeController: {dateController.PeriodController.Period}");
        }
    }
}