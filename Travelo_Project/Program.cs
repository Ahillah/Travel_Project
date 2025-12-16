
using DomainLayer.Models.Identity;
using DomainLayer.Models.User;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Persistance.RepositoryImplementation.Hotel___Accommodation;
using Persistance.RepositoryImplementation.Hotel___Accomodation;
using ServiceAbstraction.Hotel___Accommodation;
using ServiceImplementation.Hotel___Accommodation;
//using AutoMapper.QueryableExtensions.Microsoft.DependencyInjection;
using ServiceImplementation.MappingProfile.Hotel___Accommodation;
using System.Text;
using AutoMapper;
using ServiceImplementation.MappingProfile.Hotel___Accommodation;

namespace Travelo_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BaseConnection"));



            });
            //hotel
            builder.Services.AddScoped<IAmenityRepository, AmenityRepository>();
            builder.Services.AddScoped<IAmenityService, AmenityService>();
            builder.Services.AddAutoMapper(typeof(AmenityProfile));


            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddAutoMapper(typeof(RoomProfile));

            builder.Services.AddScoped<IHotelAmenityRepository, HotelAmenityRepository>();
            builder.Services.AddScoped<IHotelAmenityService, HotelAmenityService>();
            builder.Services.AddAutoMapper(typeof(HotelAmenityProfile));

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddAutoMapper(typeof(HotelProfile));
            builder.Services.AddAutoMapper(typeof(HotelDetailsProfile));

            builder.Services.AddScoped<IPriceAndAvailabilityRepository, PriceAndAvailabilityRepository>();
            builder.Services.AddScoped<IPriceAndAvailbilityService, PriceAndAvailbilityService>();
            builder.Services.AddAutoMapper(typeof(PriceAndAvailabilityProfile));

            ////builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





            //end
            builder.Services.AddAuthentication(
                  cobfig =>
                  {
                      cobfig.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                      cobfig.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                  }
                  ).AddJwtBearer(
                  options =>
                  {
                      options.TokenValidationParameters = new TokenValidationParameters()
                      {
                          ValidateIssuer = true,
                          ValidIssuer = builder.Configuration.GetSection("JwtOptions")["Issuer"],
                          ValidateAudience = true,
                          ValidAudience = builder.Configuration.GetSection("JwtOptions")["Audience"],
                          ValidateLifetime = true,
                          IssuerSigningKey = new SymmetricSecurityKey((Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtOptions")["SecretKey"])))

                      };


                  }
                  );
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            var app = builder.Build();

                  // Configure the HTTP request pipeline.
                  if (app.Environment.IsDevelopment())
                  {
                      app.MapOpenApi();
                app.MapOpenApi();
               
            }

                  app.UseHttpsRedirection();

                  app.UseAuthorization();
          
            app.UseRouting();
            app.UseAuthentication();
    


            app.MapControllers();

                  app.Run();
              }
    }
    } 
