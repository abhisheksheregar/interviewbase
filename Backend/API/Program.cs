using interviewbase;
using interviewbase.Infrastructure;
using InterviewBase.Application.Interfaces;
using InterviewBase.Application.Repository;
using InterviewBase.Application.Services;
using InterviewBase.Infrastructure.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token below"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
builder.Services.AddDbContext<AppDbContext>(options => {
  options.UseNpgsql(
  builder.Configuration.GetConnectionString("DbConnectionString"));
  options.EnableSensitiveDataLogging();
  options.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["AzureAd:Authority"];
    options.Audience = builder.Configuration["AzureAd:Audience"];
    options.SaveToken = true;
});
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ITopicsRepository, TopicsRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ITopicsService, TopicsService>();

var app = builder.Build();
app.UseCors("AllowAll");
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
