// Copyright (c) Microsoft. All rights reserved.

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Http;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Diagnostics;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services.External
{
    public interface IDiagnosticsClient
    {
        Task<bool> SendAsync(string data);
    }

    public class DiagnosticsClient : IDiagnosticsClient
    {
        private readonly IHttpClient httpClient;
        private readonly IServicesConfig config;

        public DiagnosticsClient(IHttpClient httpClient, IServicesConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public async Task<bool> SendAsync(string data)
        {
            var request = new HttpRequest();
            request.SetUriFromString(this.config.DiagnosticsEndpointUrl);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            request.SetContent(content);
            var response = await this.httpClient.PostAsync(request);

            return response.IsSuccess;
        }
    }
}