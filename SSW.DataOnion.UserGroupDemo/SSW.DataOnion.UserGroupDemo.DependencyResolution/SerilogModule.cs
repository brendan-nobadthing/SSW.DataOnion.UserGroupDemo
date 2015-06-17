using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serilog;

namespace SSW.DataOnion.UserGroupDemo.DependencyResolution
{
    public class SerilogModule : Module
    {

        private readonly string _logFilePattern;
        private readonly string _seqUrl;

        public SerilogModule(string logFilePattern, 
            string seqUrl)
        {
            _logFilePattern = logFilePattern;
            _seqUrl = seqUrl;
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => SerilogConfig.CreateLogger(_logFilePattern, _seqUrl)).As<ILogger>()
                .SingleInstance();
        }


        public class SerilogConfig
        {
            public static ILogger CreateLogger(string logFilePattern, string seqUrl)
            {
                var config = new LoggerConfiguration()
                    .MinimumLevel.Verbose();

                config.WriteTo.ColoredConsole();

                if (!string.IsNullOrEmpty(logFilePattern))
                {
                    config = config.WriteTo.RollingFile(logFilePattern);
                }

                if (!string.IsNullOrEmpty(seqUrl))
                {
                    config = config.WriteTo.Seq(seqUrl);
                }

                InitialiseGlobalContext(config);

                Log.Logger = config.CreateLogger(); // register as global static
                return Log.Logger;
            }



            public static LoggerConfiguration InitialiseGlobalContext(LoggerConfiguration configuration)
            {
                return configuration.Enrich.WithMachineName()
                                    .Enrich.WithProperty("ApplicationName", typeof(SerilogConfig).Assembly.GetName().Name)
                                    .Enrich.WithProperty("UserName", Environment.UserName)
                                    .Enrich.WithProperty("AppDomain", AppDomain.CurrentDomain)
                                    .Enrich.WithProperty("RuntimeVersion", Environment.Version)
                    // this ensures that calls to LogContext.PushProperty will cause the logger to be enriched
                                    .Enrich.FromLogContext();
            }
        }



    }
}
