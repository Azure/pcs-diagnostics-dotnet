// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime
{
    public interface IServicesConfig
    {
        string DiagnosticsEndpointUrl { get; }
        string SolutionType { get; }
        string DeploymentId { get; }
    }

    public class ServicesConfig : IServicesConfig
    {
        public string DiagnosticsEndpointUrl { get; set; }
        public string SolutionType { get; set; }
        public string DeploymentId { get; set; }
    }
}