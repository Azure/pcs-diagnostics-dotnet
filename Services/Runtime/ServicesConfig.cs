// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime
{
    public interface IServicesConfig
    {
        string DiagnosticsEndpointUrl { get; }
        string SolutionType { get; }
        string DeploymentId { get; }
        string SubscriptionId { get; }
        string IoTHubName { get; }
        string CloudType { get; }
        string SolutionName { get; }
    }

    public class ServicesConfig : IServicesConfig
    {
        public string DiagnosticsEndpointUrl { get; set; }
        public string SolutionType { get; set; }
        public string DeploymentId { get; set; }
        public string SubscriptionId { get; set; }
        public string IoTHubName { get; set; }
        public string CloudType { get; set; }
        public string SolutionName { get; set; }
    }
}