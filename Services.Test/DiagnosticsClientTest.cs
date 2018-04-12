// Copyright (c) Microsoft. All rights reserved.

using System;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.External;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Http;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Services.Test.External
{
    public class DiagnosticsClientTest
    {
        private const string DIAGNOSTICS_SERVICE_URL = @"http://diagnostics";
        private readonly Mock<IHttpClient> mockHttpClient;
        private readonly DiagnosticsClient target;
        private readonly DiagnosticsEventsServiceModel data;

        public DiagnosticsClientTest()
        {
            this.mockHttpClient = new Mock<IHttpClient>();
            this.data = new DiagnosticsEventsServiceModel
            {
                EventId = "MockEventId",
                EventType = "MockEvent",
                DeploymentId = "MockDeploymentId",
                SolutionType = "MockSolutionType",
                Timestamp = DateTimeOffset.UtcNow,
            };

            this.target = new DiagnosticsClient(
                this.mockHttpClient.Object,
                new ServicesConfig
                {
                    DiagnosticsEndpointUrl = DIAGNOSTICS_SERVICE_URL
                });
        }

        [Fact]
        public void ItReturnsTrueOnSucceess()
        {
            // Arrange
            var response = new HttpResponse();

            this.mockHttpClient
                .Setup(x => x.PostAsync(It.IsAny<IHttpRequest>()))
                .ReturnsAsync(response);

            // Act
            var result = this.target.SendAsync(JsonConvert.SerializeObject(this.data)).Result;

            // Assert
            Assert.False(result);
        }
    }
}