﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using lab_app_web_servidor_istea.Database;
using lab_app_web_servidor_istea.Interfaces;
using lab_app_web_servidor_istea.Services;
using lab_app_web_servidor_istea.Database.UnitOfWork;
using lab_app_web_servidor_istea.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
  option.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT", Version = "v1" });
  option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Ingrese Token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
  });
  option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
//--------------------------------------------------------------------------------

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IComandaService, ComandaService>();
builder.Services.AddScoped<IMesaService, MesaService>();

builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<IComandaRepository, ComandaRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<RestauranteContext>(),
    x.GetRequiredService<IComandaRepository>(),
    x.GetRequiredService<IEmpleadoRepository>(),
    x.GetRequiredService<IPedidoRepository>(),
    x.GetRequiredService<ISectorRepository>(),
    x.GetRequiredService<IMesaRepository>()
));
builder.Services.AddAutoMapper(typeof(Program));


//-----------------------------JWT---------------------------------------------


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero,
        ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
              builder.Configuration["Jwt:Issuer"], new OpenIdConnectConfigurationRetriever(),
              new HttpDocumentRetriever() { RequireHttps = false })
      };
    });
//----------------------------------------------------------------

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
