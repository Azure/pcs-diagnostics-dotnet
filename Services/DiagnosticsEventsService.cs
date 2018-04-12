// Copyright (c) Microsoft. All rights reserved.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Diagnostics;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.External;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;
using Newtonsoft.Json;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services
{
    public interface ILogDiagnostics
    {
        Task<bool> LogEventsAsync(DiagnosticsEventsServiceModel data);
    }

    public class DiagnosticsEventsService : ILogDiagnostics
    {
        private readonly ILogger log;
        private readonly IDiagnosticsClient diagnosticsClient;

        public DiagnosticsEventsService(
            IDiagnosticsClient diagnosticsClient,
            ILogger logger)
        {
            this.log = logger;
            this.diagnosticsClient = diagnosticsClient;
        }

        public async Task<bool> LogEventsAsync(DiagnosticsEventsServiceModel data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            return await this.diagnosticsClient.SendAsync(jsonData);
        }
    }
}
