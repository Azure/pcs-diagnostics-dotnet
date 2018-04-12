// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models
{
    public class DiagnosticsEventsServiceModel
    {
        [JsonProperty(PropertyName = "EventId", Order = 10)]
        public string EventId { get; set; }

        [JsonProperty(PropertyName = "EventType", Order = 20)]
        public string EventType { get; set; }

        [JsonProperty(PropertyName = "DeploymentId", Order = 30)]
        public string DeploymentId { get; set; }

        [JsonProperty(PropertyName = "SolutionType", Order = 40)]
        public string SolutionType { get; set; }

        [JsonProperty(PropertyName = "Timestamp", Order = 50)]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty(PropertyName = "SessionId", Order = 60)]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "EventProperties", Order = 70)]
        public Dictionary<string, object> EventProperties { get; set; }
    }
}