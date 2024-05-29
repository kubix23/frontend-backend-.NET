using application.Server.Data.Database;
using application.Server.Init;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using application.Server.Data.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DB>(opt =>opt.UseInMemoryDatabase("ContactList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DB>();
    context.Database.EnsureCreated();
    InitialData.addContacts(context);
    context.users.Add(new User(){login = "test", password = "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff" });
    context.SaveChanges();
}

app.Run();
