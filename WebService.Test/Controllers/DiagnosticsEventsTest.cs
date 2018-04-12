// Copyright (c) Microsoft. All rights reserved.

using Microsoft.Azure.IoTSolutions.Diagnostics.Services;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Diagnostics;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;
using Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Controllers;
using Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Models;
using Moq;
using Xunit;

namespace WebService.Test.Controllers
{
    public class DiagnosticsEventsTest
    {
        private readonly Mock<ILogDiagnostics> logDiagnosticsService;
        private readonly Mock<ILogger> log;
        private readonly DiagnosticsEvents target;
        private readonly DiagnosticsEventsApiModel data;

        public DiagnosticsEventsTest()
        {
            this.logDiagnosticsService = new Mock<ILogDiagnostics>();
            this.log = new Mock<ILogger>();

            this.data = new DiagnosticsEventsApiModel
            {
                EventType = "MockEvent"
            };

            this.target = new DiagnosticsEvents(
                this.logDiagnosticsService.Object);
        }

        [Fact]
        public void ItReturnsTrueOnSuccess()
        {
            // Arrange
            this.logDiagnosticsService
                .Setup(x => x.LogEventsAsync(It.IsAny<DiagnosticsEventsServiceModel>()))
                .ReturnsAsync(true);

            // Act
            var result = this.target.PostAsync(this.data).Result;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ItReturnsFalseOnFailure()
        {
            // Arrange
            this.logDiagnosticsService
                .Setup(x => x.LogEventsAsync(It.IsAny<DiagnosticsEventsServiceModel>()))
                .ReturnsAsync(false);

            // Act
            var result = this.target.PostAsync(this.data).Result;

            // Assert
            Assert.False(result);
        }
    }
}