# Matt Callahan's API

## [mfcallahan-dev.com](https://mfcallahan-dev.com)

This repo contains a sample REST API created with .NET Core 3.1 and deployed to Azure as an App Service. API Documentaion was created with [Swagger/Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore), and can be viewed [here](https://mfcallahan-dev.com). This project is intended to demonstrate the patterns and best practices I like to leverage in the software I develop, including dependecy injection, SOLID principles, unit testing, and clean code organization. View the source code here, and feel free to use any or all of it to help build your own ASP.NET Core Web API application.

### API Endpoints:

- /api/Utils/Hello [GET]
- /api/Utils/Hello [POST]
- /api/Utils/ThrowException [GET]
- /api/Utils/ThrowException [POST]
- /api/Utils/RandomString [GET]
- /api/Utils/RandomInt [GET]
- /api/Utils/DelayedResponse [GET]
- /api/Geocode/SingleAddress [GET]
- /api/Geocode/BatchAddress [POST]

Test the API with the [interactive documentation](https://mfcallahan-dev.com).

Contact: matthew.callahan@outlook.com