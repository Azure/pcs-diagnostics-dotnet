// Copyright (c) Microsoft. All rights reserved.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services;
using Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Filters;
using Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Models;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Controllers
{
    [Route(Version.Path + "/[controller]"), TypeFilter(typeof(ExceptionsFilterAttribute))]
    public sealed class DiagnosticsEvents : Controller
    {
        private readonly ILogDiagnostics logDiagnosticsService;

        public DiagnosticsEvents(ILogDiagnostics logDiagnosticsService)
        {
            this.logDiagnosticsService = logDiagnosticsService;
        }

        [HttpPost]
        public async Task<bool> PostAsync(
            [FromBody] DiagnosticsEventsApiModel data)
        {
            return await this.logDiagnosticsService.LogEventsAsync(data.ToServiceModel());
        }
    }
}
