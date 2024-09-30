using LoggingApi.Service;
using Microsoft.EntityFrameworkCore;
using Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoggingApi.Data.LADbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILoggingService, LoggingService>();

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LoggingApi.Data.LADbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
//app.UseHttpsRedirection();

app.Run();