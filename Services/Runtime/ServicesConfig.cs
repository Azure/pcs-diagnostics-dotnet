// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime
{
    public interface IServicesConfig
    {
        string DiagnosticsEndpointUrl { get; }
    }

    public class ServicesConfig : IServicesConfig
    {
        public string DiagnosticsEndpointUrl { get; set; }
    }
}
