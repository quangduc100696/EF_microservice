using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Exceptions;

namespace Infrastructure.Logging
{
    public static class LoggingExtentions
    {
        public static Logger AddLogging(IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Filter.ByExcluding(x => x.Properties.Any(y => y.Value.ToString().Contains("swagger")))
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
                
            return logger;
        } 


    }
}
