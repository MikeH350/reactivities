using Application.Activities.Queries;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
builder.Services.AddMediatR(x => 
    x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
    

var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapControllers();

//If we want to dispose of something when we're done with it, use the Using keyword. so garbage collection will pick it up
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>(); //gives us access to our DBcontext (Database)
    await context.Database.MigrateAsync(); //applies any pending migrations to the db, will create the db if it doesn't already exist.
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{ 
    var logger = services.GetRequiredService<ILogger<Program>>();
    //log any exception
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
