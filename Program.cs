var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(options =>
{
    options.AddConsole();  // Enables console logging
    options.AddDebug();    // Enables Debug output
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs
builder.Services.AddSwaggerGen(); // Add Swagger services
builder.Services.AddControllers();//Add Controllers services


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI accessible at the root URL
    }); 

}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

