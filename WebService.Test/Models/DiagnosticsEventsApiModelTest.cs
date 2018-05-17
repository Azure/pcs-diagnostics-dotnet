// Copyright (c) Microsoft. All rights reserved.

using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Models;
using Microsoft.Azure.IoTSolutions.Diagnostics.Services.Runtime;
using Microsoft.Azure.IoTSolutions.Diagnostics.WebService.v1.Models;
using Xunit;

namespace WebService.Test.Controllers
{
    public class DiagnosticsEventsApiModelTest
    {
        [Fact]
        public void ItSetsConfigDataInServiceModel()
        {
            // Arrange
            DiagnosticsEventsApiModel target = new DiagnosticsEventsApiModel();
            ServicesConfig config = new ServicesConfig
            {
                DeploymentId = "Id1",
                SolutionType = "Sample"
            };

            // Act
            DiagnosticsEventsServiceModel model = target.ToServiceModel(config);

            // Assert
            Assert.Equal(config.DeploymentId, model.DeploymentId);
            Assert.Equal(config.SolutionType, model.SolutionType);
        }
    }
}