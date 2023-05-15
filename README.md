## Overview

The RestSharp Demo is a .NET application that utilizes the RestSharp library to make API calls with JWT authentication. This program is designed to query an API endpoint at http://example.com/api/endpoint with additional query parameters. It reads the authentication configuration from the appsettings.json file using the Options pattern.
Installation

To use the RestSharp Demo application, follow these steps:

    Clone the repository or obtain the code from the source.
    Open the solution file in Visual Studio [version].
    Build the solution to ensure all dependencies are resolved.
    Modify the appsettings.json file to include the necessary configuration for the API endpoint and authentication.
    Save the modified appsettings.json file.
    Run the program.

## Usage

This demo project is using .Net 6. Note: Make sure you have the [.NET SDK installed](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) on your machine before using the dotnet CLI commands. You can download the latest version of the .NET SDK from the official Microsoft website. To run the RestSharp Demo application, follow these steps:

1. Restore the dependencies by navigating to the project's root directory in the command line and executing the following command:

    `dotnet restore`

This command will download and restore all the necessary packages and dependencies required by the application.

2. Build the application by running the following command:

    `dotnet build`

This command will compile the source code and generate the executable files.

3. Once the build is successful, you can run the application using the following command:

    `dotnet run`

This command will execute the application, and you will see the output in the command line or terminal.

### Application flow

    The program will read the authentication configuration from the appsettings.json file.
    The program will create an authenticator object based on the provided identity configuration.
    The program will create a RestSharp client with the specified API endpoint and authenticator.
    The program will construct a request to the API endpoint with query parameters.
    The program will send the request to the API and await the response.
    If the response is successful (HTTP status code 200), the program will print the response content.
    If the response is not successful, the program will print the error message from the response.
    The program will print "Completed!" to indicate the process is finished.

### Configuration

The RestSharp Demo application requires configuration through the appsettings.json file. The following configuration options are available:

    BaseUrl: The base URL of the API endpoint.
    IdentityConfig:SectionName: The section name in the appsettings.json file where the identity configuration is specified.
    IdentityConfig:Username: The username for authentication.
    IdentityConfig:Password: The password for authentication.

Ensure that the appsettings.json file is properly configured before running the program.

## Troubleshooting

If you encounter any issues while using the RestSharp Demo application, consider the following troubleshooting steps:

    Check if the appsettings.json file exists and is correctly configured with the required information.
    Verify that the API endpoint is accessible and running.
    Ensure that the authentication credentials (username and password) are valid.
    Check the error message from the program for any additional details.
    If the issue persists, [provide contact information or links to relevant support channels].
