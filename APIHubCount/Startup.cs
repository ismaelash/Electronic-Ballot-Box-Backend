using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Service;

namespace ElectronicBallotBox
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddScoped<Context, Context>();
            services.AddTransient<VoteService, VoteService>();
            services.AddTransient<CandidateService, CandidateService>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Electronic Ballot Box API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("MyPolicy");
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Ismael Nascimento `Ash` - V1");
                x.RoutePrefix = string.Empty;
            });
        }
    }
}