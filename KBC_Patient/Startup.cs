using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KBC_Patient.Data;
using KBC_Patient.Data.Interfaces;
using KBC_Patient.Repositories;
using KBC_Patient.Repositories.Interfaces;
using KBC_Patient.Settings;
using KBC_Patient.Settings.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace KBC_Patient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Database Implementations
            
            services.Configure<PatientsDatabaseSettings>(Configuration.GetSection(nameof(PatientsDatabaseSettings)));
            services.AddSingleton<IPatientsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<PatientsDatabaseSettings>>().Value);
            services.AddTransient<IPatientDataContext,PatientDataContext>();
            
            services.Configure<DeviceDatabaseSettings>(Configuration.GetSection(nameof(DeviceDatabaseSettings)));
            services.AddSingleton<IDeviceDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DeviceDatabaseSettings>>().Value);
            services.AddTransient<IDeviceDataContext,DeviceDataContext>();
            #endregion

            #region Repository

            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();

            #endregion
            
            
            #region Controller

            services.AddControllers();

            #endregion
            #region Swagger
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "KBC_Patient", Version = "v1"});
            });
            

            #endregion
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KBC_Patient v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}