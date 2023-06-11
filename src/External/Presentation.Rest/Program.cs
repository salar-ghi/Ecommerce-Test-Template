var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.AddServiceRegistery();

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/Error");
    }

    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}
catch(Exception exception)
{
    logger.Error(exception, "stopped program because of exception"); ;
    throw;
}
finally
{
    LogManager.Shutdown();
}