// Copyright (c) Microsoft. All rights reserved.

using System;
using System.IO;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;

namespace Microsoft.Azure.IoTSolutions.Diagnostics.WebService.Runtime
{
    public interface IConfig
    {
        /// <summary>Web service listening port</summary>
        int Port { get; }

        /// <summary>Example of a path setting</summary>
        string SomeFolder { get; }

        /// <summary>Service layer configuration</summary>
        IServicesConfig ServicesConfig { get; }
    }

    /// <summary>Web service configuration</summary>
    public class Config : IConfig
    {
        private const string ApplicationKey = "diagnostics:";
        private const string PortKey = ApplicationKey + "webservice_port";

        /// <summary>Web service listening port</summary>
        public int Port { get; }

        /// <summary>Example of a path setting</summary>
        public string SomeFolder { get; }

        /// <summary>Service layer configuration</summary>
        public IServicesConfig ServicesConfig { get; }

        public Config(IConfigData configData)
        {
            this.Port = configData.GetInt(PortKey);

            this.ServicesConfig = new ServicesConfig();
        }

        private static string MapRelativePath(string path)
        {
            if (path.StartsWith(".")) return AppContext.BaseDirectory + Path.DirectorySeparatorChar + path;
            return path;
        }
    }
}
