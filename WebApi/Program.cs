using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDb"));
});

builder.Services.AddScoped<IRepository<EmployeeModel, EmployeeEntity>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<DepartmentModel, DepartmentEntity>, DepartmentRepository>();
builder.Services.AddScoped<IRepository<PositionModel, PositionEntity>, PositionRepository>();
builder.Services.AddScoped<IRepository<SalaryModel, SalaryEntity>, SalaryRepository>();
builder.Services.AddScoped<IRepository<ContractModel, ContractEntity>, ContractRepository>();
builder.Services.AddScoped<IRepository<AttendanceModel, AttendanceEntity>, AttendanceRepository>();
builder.Services.AddScoped<IRepository<CandidateModel, CandidateEntity>, CandidateRepository>();
builder.Services.AddScoped<IRepository<EvaluateModel, EvaluateEntity>, EvaluationRepository>();
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes =  Encoding.UTF8.GetBytes(secretKey);
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

        ClockSkew = TimeSpan.Zero
    };
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
