using Microsoft.EntityFrameworkCore;
using App.DAL.Data;
using App.DAL.Repository.Contracts;
using App.BLL.Services.Contracts;



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
         policy =>
         {
            policy.WithOrigins("http://localhost:3001/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();   
         });
});


builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
ConfigurationManager configuration = builder.Configuration; 

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IAssignmentService, AssignmentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMvc();
app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
