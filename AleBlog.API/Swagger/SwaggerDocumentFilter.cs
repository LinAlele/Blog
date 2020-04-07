using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace AleBlog.API.Swagger
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tags = new List<OpenApiTag>
            {
                new OpenApiTag
                {
                    Name = "Test",
                    Description = "测试",
                    ExternalDocs = new OpenApiExternalDocs { Description = "测试数据" }
                }
            };
            swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
        }
    }
}
