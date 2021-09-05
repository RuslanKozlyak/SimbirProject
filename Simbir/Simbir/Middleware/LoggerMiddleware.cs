using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Simbir.Middleware
{
    public class LoggerMiddleware
    {
        /// <summary>
        /// Часть 2.2 п.3 Создание middleware логирования времени
        /// отклика запроса
        /// </summary>
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string elapsedTime = "";
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                await _next(httpContext);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
                _logger.LogInformation($"Processing time of " +
                    $"{httpContext.Request?.Method} request = {elapsedTime}");
            }
            
        }
    }
}

