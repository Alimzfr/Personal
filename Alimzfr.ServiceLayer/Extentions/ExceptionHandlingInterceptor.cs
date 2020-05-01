using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ServiceLayer.Extentions
{
    public class ExceptionHandlingInterceptor : IInterceptor
    {
        private readonly ILogger<ExceptionHandlingInterceptor> _logger;

        public ExceptionHandlingInterceptor(ILogger<ExceptionHandlingInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An unhandled exception has been occurred.");
            }
        }
    }
}
