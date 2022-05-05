using ApiWkTechnology.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
//Injetando Swagger
builder.Services.AddSwaggerGen();
//Injetando Repositorys
builder.Services.AddRepositorysExtension();
//Injetando Servicos
builder.Services.AddServicesExtension();
//Injetando Base de dados como contexto
builder.Services.AddDatabaseInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
