using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace Noscape
{
    /// <summary>
    /// This class handles HTTP requests asynchronously.
    /// </summary>
    public class HTTPHandler
    {
        private HttpClient client;
        private HttpClientHandler chandler;
        private CancellationTokenSource ct;

        /// <summary>
        /// HttpHandler constructor.
        /// </summary>
        public HTTPHandler()
        {
            chandler = new HttpClientHandler();
            chandler.AllowAutoRedirect = true;
            client = new HttpClient(chandler);
            ct = new CancellationTokenSource();
        }

        /// <summary>
        /// Get the HTML response to a given URL.
        /// </summary>
        /// <remarks>
        /// This method will always force the ongoing/previous Task to cancel using a CancellationToken
        /// before starting a new request. This ensures a previous request will not load after the current
        /// request has completed.
        /// </remarks>
        /// <param name="url">The URL for the new request.</param>
        /// <returns>An asynchronous Task which itself will eventually turn a HttpResponseMessage object</returns>
        public async Task<HttpResponseMessage> GetHTMLAsync(String url)
        {
            ct.Cancel();                            // Cancel previous Task
            ct = new CancellationTokenSource();     // Create a new CT for this Task

            HttpResponseMessage result = await client.GetAsync(url, ct.Token);
            Console.WriteLine("[HttpHandler] {0} returned code: {1}", url, result.StatusCode);

            return result;
        }

    }
}
