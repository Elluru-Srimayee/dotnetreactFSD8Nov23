using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using HotelBookingApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelBookingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // ConfigureServices method
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
                        ValidateIssuerSigningKey = true
                    };
                });

            builder.Services.AddDbContext<HotelDbContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("shoppingCon"));
            });
            builder.Services.AddScoped<IRepository<int, Hotel>, HotelRepository>();
            builder.Services.AddScoped<IRepository<int, Room>, RoomRepository>();
            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IHotelService>(provider =>
                new HotelService(provider.GetService<IRepository<int, Hotel>>()));

            builder.Services.AddScoped<IRoomService>(provider =>
                new RoomService(provider.GetService<IRepository<int, Room>>()));

            builder.Services.AddScoped<IUserService>(provider =>
                new UserService(
                    provider.GetService<IRepository<string, User>>(),
                    provider.GetService<ITokenService>()
                ));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();

            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}