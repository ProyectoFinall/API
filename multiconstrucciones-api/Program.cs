using Microsoft.EntityFrameworkCore;
using multiconstrucciones_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MulticonstruccionesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbCnn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(options => options
    .WithOrigins("http://localhost:4200", "https://civ.herokuapp.com"
    , "https://civ.herokuapp.com/", "http://civ.herokuapp.com", "http://civ.herokuapp.com/"
    , "https://multiconstrucciones.herokuapp.com/", "http://multiconstrucciones.herokuapp.com/", "http://multiconstrucciones.herokuapp.com")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
