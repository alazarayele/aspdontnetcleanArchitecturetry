
using cleanarchitecture.Api;
using cleanarchitecture.Api.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory, cleanarchitectureProblemDetailsFactory>();
//builder.Services.AddApplicationRegistraion();
builder.Services.AddApplicationReg();
builder.Services.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);  
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
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
// app.Map("/error",(HttpContext httpContext)=>
// {
//     Exception? exception =  httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//     return Results.Problem();
// });
app.UseHttpsRedirection();
app.UseAuthentication();

app.MapControllers();

app.Run();
