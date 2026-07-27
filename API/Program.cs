using interviewbase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("http://localhost:4200","https://interviewbase-ui.onrender.com")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => {
  options.UseNpgsql(
  builder.Configuration.GetConnectionString("DbConnectionString"));
  options.EnableSensitiveDataLogging();
  options.LogTo(Console.WriteLine, LogLevel.Information);
});
  
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  try
  {
    bool conn = db.Database.CanConnect();
    var result = await db.Database.ExecuteSqlRawAsync("select 1");
    Console.WriteLine(conn ? "success" : "failure");
  }
  catch (Exception ex) { Console.WriteLine(ex.ToString()); }
}
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
