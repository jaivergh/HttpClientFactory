using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestWeb21
{
    public class RetryHandler : DelegatingHandler
    {
        public RetryHandler(RetryHandlerOptions options)
        {
            this.Options = options;
        }

        public RetryHandlerOptions Options { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {

            for (int i = 0; true; i++)
            {
                try
                {
                    return await base.SendAsync(message, cancellationToken);
                }
                catch (HttpRequestException) when (i == Options.RetryCount)
                {                    
                    throw;
                }
                catch (HttpRequestException)
                {
                    await Task.Delay(100);
                }
            }

            throw new ApplicationException("It should't make to here");

            
        }
    }

    public class RetryHandlerOptions
    {
        public int RetryCount { get; set; }
    }

}