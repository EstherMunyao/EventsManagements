using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using EventsGQL;
using Dapper;
using EventsGQL.Models;
using System.Data;
//using System.Collection.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
//using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

//var connectionstring = "server = (localdb)\\mssqllocaldb; Database = EventsDb; Trusted_Connection = True;";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigins",
    policy => policy.WithOrigins("http://localhost:5000", "https://preview.flutlab.io")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
});
builder.Services.AddSwaggerGen();
builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddMutationType<Mutation>();
// builder.Services.AddSingleton<DapperContext>();
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("EventsDb")));


var app = builder.Build();

 //Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseCors("AllowLocal5000");
app.UseCors("AllowSpecificOrigins");
app.MapGraphQL("/graphql");
app.UseHttpsRedirection();

// app.MapGet("/", ()=>{
//      var eventsItem = new EventsItem (){
//         Id = 4,
//         Name = "gear",
//         IsComplete = false
//      };
//      return eventsItem;

// });
//app.MapGraphQL();
app.Run();

