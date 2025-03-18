
using Microsoft.EntityFrameworkCore;
using StudentHostel.DAL.Database;
using StudentHostel.BLL.Service.IService;
using StudentHostel.BLL.Service;
using StudentHostelAPI.Extention;
using StudentHostel.BLL.Service.TokenService;
using StudentHostel.BLL.Repo;
using StudentHostel.BLL.Repo.IRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using StudentHostel.DAL.Entites;

namespace StudentHostelAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Console.WriteLine($"JWT Key: {builder.Configuration["Jwt:Key"]}");

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
            builder.Services.AddScoped<IApartmentRepo, ApartmentRepo>();
            builder.Services.AddScoped<ICommentRepo, CommentRepo>();
            //service
            builder.Services.AddScoped<IAppUserService, AppUserService>();
            builder.Services.AddScoped<IApartmentService, ApartmentService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddDbContext<ApplicationDbContext>(
              (options) =>
              {
                  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
              }

                   );

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(30); 
            });
           


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
