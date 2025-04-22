using PortFolioPolLESSIRE0.DAL.Repositories;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using PortFolioPolLESSIRE0.BLL.Services;
using PortFolioPolLESSIRE0.BLL.Interfaces;
using System.Data.SqlClient;
using PortFolioPolLESSIRE1.API.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//SqlConnection

builder.Services.AddScoped<SqlConnection>(Sc => new SqlConnection(builder.Configuration.GetConnectionString("default")));

// Injections

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICertificationService, CertificationService>();
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<IInterestService, InterestService>();
builder.Services.AddScoped<IInterestRepository, InterestRepository>();

builder.Services.AddControllers();

// Add SignalR
builder.Services.AddSignalR();

// Add Hubs
builder.Services.AddScoped<ExperienceHub>();
builder.Services.AddScoped<LanguageHub>();
builder.Services.AddScoped<EducationHub>();
builder.Services.AddScoped<ContactHub>();
builder.Services.AddScoped<CertificationHub>();
builder.Services.AddScoped<ProjectHub>();
builder.Services.AddScoped<SkillHub>();

// Blazor Connection
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7109", "http://localhost:5270")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenLocalhost(7210, listenOptions =>
//    {
//        listenOptions.UseHttps(); // nécessite cert local (VS l’ajoute)
//    });
//});
    

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
app.UseRouting();
app.UseCors("AllowBlazorClient");

app.UseAuthorization();
app.UseEndpoints(Endpoints =>
{
    Endpoints.MapControllers();
    Endpoints.MapHub<CertificationHub>("/hubs/certificationHub");
    Endpoints.MapHub<ContactHub>("/hubs/contactHub");
    Endpoints.MapHub<EducationHub>("/hubs/educationHub");
    Endpoints.MapHub<ExperienceHub>("/hubs/experienceHub");
    Endpoints.MapHub<InterestHub>("/hubs/interestHub");
    Endpoints.MapHub<LanguageHub>("/hubs/languageHub");
    Endpoints.MapHub<ProjectHub>("/hubs/projectHub");
    Endpoints.MapHub<SkillHub>("/hubs/skillHub");
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    await next();
});

//app.MapControllers();

app.Run();























//Copyrite https://github.com/POLLESSI