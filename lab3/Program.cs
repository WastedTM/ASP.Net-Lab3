using lab3;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
builder.Services.AddTransient<ICalcMethod, CalcService>();
builder.Services.AddTransient<IDateTimeService, DateTimeService>();
builder.Services.AddTransient<DateTimeController>();
var app = builder.Build();

app.UseMiddleware<Middleware>();

app.Run();