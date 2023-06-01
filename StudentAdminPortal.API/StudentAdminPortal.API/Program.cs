using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string ConnectionStr = "Data Source= (localdb)\\Local; Initial Catalog=StudentAdminPortal; Integrated Security=True; TrustServerCertificate=True;";
builder.Services.AddDbContext<StudentAdminContext>(options => options.UseSqlServer(ConnectionStr));



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
