using MM.RequestResponseMiddleware.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLogging(conf =>
{
    conf.AddConsole();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.AddMMRequestResponseMiddleware(opt =>
{
    //opt.UseHandler(async context =>
    //{
    //    Console.WriteLine($"RequestBody: {context.RequestBody}");
    //    Console.WriteLine($"ResponseBody: {context.ResponseBody}");
    //    Console.WriteLine($"Timing: {context.FormattedCreationTime}");
    //    Console.WriteLine($"URL: {context.Url}");
    //});

    opt.UseLogger(app.Services.GetRequiredService<ILoggerFactory>(), opt =>
    {
        opt.LogLevel = LogLevel.Error;
        opt.LoggerCategoryName = "RequestResponseLoggerMiddleware";

        opt.LoggingFields.Add(MM.RequestResponseMiddleware.Library.Enum.LogFields.Request);
        opt.LoggingFields.Add(MM.RequestResponseMiddleware.Library.Enum.LogFields.Response);
        opt.LoggingFields.Add(MM.RequestResponseMiddleware.Library.Enum.LogFields.ResponseTiming);
        opt.LoggingFields.Add(MM.RequestResponseMiddleware.Library.Enum.LogFields.Path);
        opt.LoggingFields.Add(MM.RequestResponseMiddleware.Library.Enum.LogFields.QueryString);
    });

});

app.MapControllers();

app.Run();
