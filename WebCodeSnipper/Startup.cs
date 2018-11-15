using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace WebCodeSnipper
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //获取编译器生成的xml文档路径
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwaggerGen(config =>
            {
                //APiDocument 名称必须与下面端点的模板名称一致。模板为：swagger/{documentName}/swagger.json。Swagger中间件根据documentName获取APi描述。
                config.SwaggerDoc("ApiDocument", new Info()
                {
                    Title = "ValueApi",
                    Version = "1.0",
                    Description="A test swagger api document",
                    License= new License() { Name="MIT",Url="https://www.bing/com"}
                });
                config.IncludeXmlComments(xmlPath);//将文档添加到Swagger，Swagger根据xml文档生成APi文档
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //添加静态文件支持
            app.UseStaticFiles();
            //添加Swagger中间件。主要用于生成json文件。
            app.UseSwagger();
            //添加前台UI和配置入口端点
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/ApiDocument/swagger.json", "ApiDocument");
                options.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
