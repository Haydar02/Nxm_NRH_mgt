using Microsoft.EntityFrameworkCore;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;
using Nxm_NRH_mgt.NxmServices;
using Nxm_NRH_mgt.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Nxm_NRH_mgtContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IServiceRepositores, ServiceRepositores>();
builder.Services.AddScoped<IGroup_Service, Group_Service>();
builder.Services.AddScoped<IProfilingService, ProfilingService>();
builder.Services.AddScoped<IProfilingRepositories, ProfilingRepositories>();
builder.Services.AddScoped<IGroupRepositories, GroupRepositories>();
builder.Services.AddScoped<IAggregatedService, AggregatedServices>();
builder.Services.AddScoped<IAggregatedRepositpries,AggregatedRepositories>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IParticipantRepositories, ParticipantRepositories>();
builder.Services.AddScoped<IReceiverServiceRepositories, ReceiverServiceRepositories>();
builder.Services.AddScoped<IReceiverService_Services, ReceiverService_Services>();
builder.Services.AddScoped<IAggregatedServiceRelationRepositories, AggregatedServiceRelationRepositories>();
builder.Services.AddScoped<IAggregatedServiceRelationService, AggregatedServiceRelationService>();
builder.Services.AddScoped<IParticiPantBindingRepositories,ParticiPantBindingRepositories>();
builder.Services.AddScoped<IParticipantBindingService, ParticipantBindingService>();
builder.Services.AddScoped<IProfilingRoleRepositories, ProfilingRoleRepositories>();
builder.Services.AddScoped<IProfilingRoleService, ProfilingRoleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
