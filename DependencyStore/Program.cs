using DependencyStore.Extensions;
using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Constracts;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSqlConnection(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

