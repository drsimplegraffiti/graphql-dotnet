using GraphQlApi.Data;
using GraphQlApi.GraphQL.Mutations;
using GraphQlApi.GraphQL.Types;
using GraphQlApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register Service
builder.Services.AddScoped<IProductService, ProductService>();
//InMemory Database
builder.Services.AddDbContext<DbContextClass>(o => o.UseInMemoryDatabase("GraphQLDemo"));

//GraphQL Config
builder.Services.AddGraphQLServer()
    .AddQueryType<ProductQueryTypes>()
    .AddMutationType<ProductMutations>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DbContextClass>();
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

//GraphQL
app.MapGraphQL();

//REST API

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();