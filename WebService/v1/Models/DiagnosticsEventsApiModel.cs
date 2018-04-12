// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;

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

        public DiagnosticsEventsServiceModel ToServiceModel()
        {
            return new DiagnosticsEventsServiceModel
            {
                EventId = Guid.NewGuid().ToString(),
                EventType = this.EventType,
                EventProperties = this.EventProperties,
                DeploymentId = "Undefined", // This will be replaced with actual deployment id
                SolutionType = "Default", // This will be replaced with actual solution type
                Timestamp = DateTimeOffset.UtcNow
            };
        }
    }
}
