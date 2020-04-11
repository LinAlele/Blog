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
            //��ʼ���������˿�8565��Nginxת��
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


            // ·������
            services.AddRouting(options =>
            {
                //URLСд
                options.LowercaseUrls = true;
                //����URL�������б��
                options.AppendTrailingSlash = true;

              
            });
            services.AddSwagger();

            // MVC����
            services.AddMvcCore(options =>
            {
                // ���һ����Ӧ�����Ĭ������
                options.CacheProfiles.Add("default", new CacheProfile { Duration = 100 });
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            // Http����
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
            // ������������������
            if (env.IsDevelopment())
            {
                // �����쳣ҳ��
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            // ·��
            app.UseRouting();
            // ��Ӧ����
            app.UseResponseCaching();
            //����
            app.UseCors("CorsApp");
            //HTTPS
            app.UseHttpsRedirection();
            //·��ӳ��
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
