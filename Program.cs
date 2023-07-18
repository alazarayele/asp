using asp.Data;
using Microsoft.EntityFrameworkCore;
using asp.Infrastructure.Applied;
using asp.Infrastructure.Interface;
using asp.Application.Applied;
using asp.Application.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

 builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
 builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IStudent,StudentApplication>();

builder.Services.AddMvc().AddNewtonsoftJson(x=>{
    x.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var conn = builder.Configuration.GetConnectionString("DataBaseConnection");
builder.Services.AddDbContext<AspContext>(dbcontext => {
    dbcontext.UseMySql(conn,ServerVersion.AutoDetect(conn));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
