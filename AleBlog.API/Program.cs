using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AleBlog.API.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using AleBlog.API.BaseStuct;

namespace AleBlog.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //初始化并监听端口8565，Nginx转发
            await Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureKestrel(options =>{options.AddServerHeader = false;})
                    .UseUrls("http://*:5000")
                    .UseStartup<Program>();
                }).Build().RunAsync();

            //CreateHostBuilder(args).Build().Run();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(option =>
            {
                option.AddPolicy("CorsApp",
                    builder =>
                    {
                        builder.AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowCredentials();

                    });
            });


            // 路由配置
            services.AddRouting(options =>
            {
                //URL小写
                options.LowercaseUrls = true;
                //生成URL后面添加斜杠
                options.AppendTrailingSlash = true;

              
            });
            services.AddSwagger();

            // MVC服务
            services.AddMvcCore(options =>
            {
                // 添加一条响应缓存的默认配置
                options.CacheProfiles.Add("default", new CacheProfile { Duration = 100 });
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            // Http请求
            services.AddHttpClient();

            services.AddDbContext<AleBlogDbContext>();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            // 路由
            app.UseRouting();
            // 响应缓存
            app.UseResponseCaching();
            //跨域
            app.UseCors("CorsApp");
            //HTTPS
            app.UseHttpsRedirection();
            //路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Swagger
            app.UseSwagger();
            //SwaggerUI
            app.UseSwaggerUI();


        }
    }
}
