using Autofac;
using Autofac.Extensions.DependencyInjection;
using Framework.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagement.Application.Contracts;
using Framework.Autofac;
using UserManagement.Config;
using UserManagement.Domain.Contracts.Events;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new FrameworkModule(typeof(UserRegistered).Assembly));
    containerBuilder.RegisterModule(new LoanApplicationsModule());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.MapPost("RegisterUser", async (RegisterUserCommand command, [FromServices] ICommandBus bus) => {
    await bus.Dispatch(command);
    return Results.Ok();
});

app.MapPut("UpdateUserPersonalInformation", async (string id, UpdateUserPersonalInformationCommand command,
    [FromServices] ICommandBus bus) => {
    await bus.Dispatch(command);
    return Results.Ok();
});

app.MapPut("ActivateUserAccount", async (string id, ActivateUserAccountCommand command, [FromServices] ICommandBus bus) => {
    await bus.Dispatch(command);
    return Results.Ok();
});


app.UseSwagger();
app.UseSwaggerUI();



app.Run();
