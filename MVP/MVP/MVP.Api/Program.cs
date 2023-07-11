using MVP.BusinessComponents;
using MVP.EntityRepositories;
using System.Web.Services.Description;

var builder = WebApplication.CreateBuilder(args);
var CORSOpenPolicy = "OpenCORSPolicy";
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ISkillRepository, SkillRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<IJobSkillsRepository, JobSkillsRepository>();
builder.Services.AddTransient<IEmployeeSkillsRepository, EmployeeSkillsRepository>();

builder.Services.AddTransient<ISkillOperations, SkillOperations>();
builder.Services.AddTransient<IEmployeeOperations, EmployeeOperations>();
builder.Services.AddTransient<IJobOperations, JobOperations>();
builder.Services.AddTransient<IJobSkillsOperations, JobSkillsOperations>();
builder.Services.AddTransient<IEmployeeSkillsOperations, EmployeeSkillsOperations>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder =>
      {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CORSOpenPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
