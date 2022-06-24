using Application;
using ClassLibraryEntityFrameWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplicationRBAC
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

            services.AddControllers()
            .AddNewtonsoftJson(options => {
            // ����ѭ������
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // ��ʹ���շ�
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            // ����ʱ���ʽ
            options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            // ���ֶ�Ϊnullֵ�����ֶβ��᷵�ص�ǰ��
            // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplicationRBAC", Version = "v1" });
            });

            services.AddAutoMapper(Assembly.Load("Application"));

            services.AddScoped<IMeunService, MeunService>();
            services.AddScoped<IMeunRepository, MeunRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddDbContext<MyDbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("sqlserver")));

            services.AddCors(options =>
            {
                // this defines a CORS policy called "c"
                options.AddPolicy("cors", policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplicationRBAC v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("cors");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
