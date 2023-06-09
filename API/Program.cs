using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IRegistroUsuarioRepository, RegistroUsuarioRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseCors(builder => builder.AllowAnyHeader()
            .AllowAnyMethod().WithOrigins("http://localhost:4200"));






app.UseAuthorization();

app.MapControllers();

app.Run();
