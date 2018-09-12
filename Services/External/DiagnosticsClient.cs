// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Diagnostics;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Http;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services.External
{
    public interface IDiagnosticsClient
    {
        Task<bool> SendAsync(string data);
        Task<bool> CheckUserConsentAsync();
    }

    public class DiagnosticsClient : IDiagnosticsClient
    {
        private readonly IHttpClient httpClient;
        private readonly IServicesConfig config;
        private readonly ILogger logger;

        public DiagnosticsClient(IHttpClient httpClient, IServicesConfig config, ILogger logger)
        {
            this.httpClient = httpClient;
            this.config = config;
            this.logger = logger;
        }

        public async Task<bool> SendAsync(string data)
        {
            var endpointUrl = this.config.DiagnosticsEndpointUrl;

            if (string.IsNullOrEmpty((endpointUrl)))
            {
                return false;
            }

            var request = new HttpRequest();
            request.SetUriFromString(endpointUrl);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            request.SetContent(content);
            var response = await this.httpClient.PostAsync(request);

            return response.IsSuccess;
        }

        public async Task<bool> CheckUserConsentAsync()
        {
            if (string.IsNullOrEmpty(this.config.PcsConfigUrl))
            {
                return false;
            }

            var pcsConfigUrl = this.config.PcsConfigUrl + "/solution-settings/theme";
            var userConsent = true;
            var request = new HttpRequest();
            request.SetUriFromString(pcsConfigUrl);

            try
            {
                var response = await this.httpClient.GetAsync(request);

                if (response != null && response.Content != null)
                {
                    var jsonResponse = new JObject();
                    jsonResponse = JObject.Parse(response.Content);

                    if (jsonResponse["diagnosticsOptOut"] != null)
                    {
                        userConsent = !((bool)jsonResponse["diagnosticsOptOut"]);
                    }
                }
            }
            catch (Exception e)
            {
                this.logger.Error("Failed to retrieve user consent", () => new { e });
                userConsent = false;
            }

            return userConsent;
        }
    }
}
