using InfluencerAPI.Services;
using InfuencerAPI.Data;
using InfuencerAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                       new OpenApiInfo
                       {
                           Title = "API Title",
                           Version = "V1",
                           Description = "API Description"
                       });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "Authorization header using the Bearer scheme. Example \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    swagger.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securitySchema,Array.Empty<string>() }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add services to the container.

builder.Services.AddDbContext<InfluencerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("InfluencerCS")));
builder.Services.AddScoped<ISettingsService, SettingsService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IInfluencerService, InfluencerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
//var url = $"http://0.0.0.0:{port}";
//var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
//app.MapGet("/", () => $"Hello {target}!");

//app.Run(url);
