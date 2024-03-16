using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Swagger
{
    internal class SwaggerOptions : OpenApiInfo
    {
        public string VersionName { get; set; } = "v1";
        public string Title { get; set; } = "Swagger";
    }
}
