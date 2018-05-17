// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Models
{
    public class DiagnosticsEventsApiModel
    {
        [JsonProperty(PropertyName = "EventType", Order = 10)]
        public string EventType { get; set; }

        [JsonProperty(PropertyName = "EventProperties", Order = 20)]
        public Dictionary<string, object> EventProperties { get; set; }

        public DiagnosticsEventsApiModel()
        {
        }

        public DiagnosticsEventsServiceModel ToServiceModel(IServicesConfig servicesConfig)
        {
            return new DiagnosticsEventsServiceModel
            {
                EventId = Guid.NewGuid().ToString(),
                EventType = this.EventType,
                EventProperties = this.EventProperties,
                DeploymentId = servicesConfig.DeploymentId,
                SolutionType = servicesConfig.SolutionType,
                Timestamp = DateTimeOffset.UtcNow
            };
        }
    }
}
