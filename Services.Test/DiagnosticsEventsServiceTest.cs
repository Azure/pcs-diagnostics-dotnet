﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.ApplicationInsights;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Diagnostics;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.External;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;
using Moq;
using Xunit;

namespace Services.Test
{
    public class DiagnosticsEventsServiceTest
    {
        private const string DIAGNOSTICS_SERVICE_URL = @"http://diagnostics";
        private readonly Mock<IDiagnosticsClient> diagnosticsClient;
        private readonly Mock<IServicesConfig> servicesConfig;
        private readonly Mock<ITelemetryClientWrapper> mockTelemetryClientWrapper;
        private readonly DiagnosticsEventsService target;
        private readonly DiagnosticsEventsServiceModel data;

        public DiagnosticsEventsServiceTest()
        {
            this.diagnosticsClient = new Mock<IDiagnosticsClient>();
            this.servicesConfig = new Mock<IServicesConfig>();
            this.mockTelemetryClientWrapper = new Mock<ITelemetryClientWrapper>();
            this.data = new DiagnosticsEventsServiceModel
            {
                EventId = "MockEventId",
                EventType = "MockEvent",
                DeploymentId = "MockDeploymentId",
                SolutionType = "MockSolutionType",
                Timestamp = DateTimeOffset.UtcNow
            };

            this.target = new DiagnosticsEventsService(
                this.diagnosticsClient.Object,
                this.servicesConfig.Object,
                this.mockTelemetryClientWrapper.Object,
                new Logger("UnitTest"));
        }

        [Fact]
        public void ItReturnsTrueOnSucceess()
        {
           // Arrange
           this.diagnosticsClient
                .Setup(x => x.SendAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            this.diagnosticsClient
                .Setup(x => x.CheckUserConsentAsync())
                .ReturnsAsync(true);

            // Act
            var result = this.target.LogEventsAsync(this.data).Result;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ItReturnsFalseOnFailure()
        {
            // Arrange
            this.diagnosticsClient
                .Setup(x => x.SendAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            // Act
            var result = this.target.LogEventsAsync(this.data).Result;

            // Assert
            Assert.False(result);
        }
    }
}