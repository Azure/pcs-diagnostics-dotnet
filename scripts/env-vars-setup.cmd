:: Copyright (c) Microsoft. All rights reserved.

:: Prepare the environment variables used by the application.

:: Some settings are used to connect to an external dependency, e.g. backend diagnostics service
:: Depending on which settings and which dependencies are needed, edit the list of variables

:: Backend disgnostics service endpoint where requests to log data will be sent.
SETX PCS_DIAGNOSTICS_ENDPOINT_URL "backend diagnostics service url"