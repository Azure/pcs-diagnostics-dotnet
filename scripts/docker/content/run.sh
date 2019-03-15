#!/usr/bin/env bash
# Copyright (c) Microsoft. All rights reserved.

cd /app/

# Running in current shell
. set_env.sh PCS_CONFIG_WEBSERVICE_URL configWebServiceUrl PCS_SOLUTION_TYPE solutionType PCS_DEPLOYMENT_ID deploymentId PCS_SUBSCRIPTION_ID subscriptionId PCS_CLOUD_TYPE cloudType PCS_IOTHUB_NAME iotHubName PCS_SOLUTION_NAME solutionName PCS_APPINSIGHTS_INSTRUMENTATIONKEY appInsightsInstrumentationKey

cd webservice

dotnet Microsoft.Azure.IoTSolutions.Diagnostics.WebService.dll
