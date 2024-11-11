using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using ResourceTranslationApp.MIddlewares;

namespace ResourceTranslationApp.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder, IConfiguration config)
        {
            var columnOptions = new ColumnOptions
            {
                TimeStamp = { ConvertToUtc = true, ColumnName = "CreatedTimeUtc", }
            };
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Properties);
            builder.Logging.AddSerilog(new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
            .MinimumLevel.Override("Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware", LogEventLevel.Information)
            .WriteTo.MSSqlServer(
                connectionString: config.GetConnectionString("Default"),
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = "Logs",
                    AutoCreateSqlTable = true,
                },
                columnOptions: columnOptions)
            .CreateLogger());
            return builder;
        }

        /// <summary>
        /// Contains custom middlewares
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandleMiddleware>();
            return app;
        }
    }
}
