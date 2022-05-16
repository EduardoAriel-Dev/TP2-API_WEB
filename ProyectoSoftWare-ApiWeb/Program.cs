using Microsoft.EntityFrameworkCore;
using PS.Template.AccessData.Commands;
using PS.Template.AccessData.DbContexts;
using PS.Template.AccessData.Queries;
using PS.Template.Aplication.Interfaces;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Services;
using PS.Template.Aplication.Interfaces.interface_Alquiler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=DESKTOP-G01P39L; Database=M_9_DeJulio;Trusted_Connection=True;"));
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IClienteCommand, ClienteCommands>();
builder.Services.AddTransient<IQueryCliente, QueryCliente>();
builder.Services.AddTransient<IQueryLibro, QueryLibro>();
builder.Services.AddTransient<IlibroService, LibroService>();
builder.Services.AddTransient<IAlquilerCommands, AlquilerCommands>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
