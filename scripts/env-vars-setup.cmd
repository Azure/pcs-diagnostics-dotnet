:: Copyright (c) Microsoft. All rights reserved.

:: Prepare the environment variables used by the application.

:: Some settings are used to connect to an external dependency, e.g. backend diagnostics service
:: Depending on which settings and which dependencies are needed, edit the list of variables

:: Backend diagnostics service endpoint where requests to log data will be sent.
:: E.g https://<sample>.azurewebsites.net/<api>
SETX PCS_DIAGNOSTICS_ENDPOINT_URL "Enter backend diagnostics service url here"

:: Type of solution. E.g DeviceSimulation, RemoteMonitoring, etc.
SETX PCS_SOLUTION_TYPE "Enter solution type here"

:: Unique id of solution deployment
SETX PCS_DEPLOYMENT_ID "Enter deployment id here"