# Overview

This web app displays both past and upcoming launches by SpaceX, a private American aerospace manufacturer and space transportation services company. It fetches details from the SpaceX API and presents information about each launch. Users can access specific launch details.

# Technologies

- [ASP.NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [React 18](https://react.dev/learn)
- [MediatR](https://github.com/jbogard/MediatR)
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Swagger UI](https://github.com/swagger-api/swagger-ui)
- [NUnit](https://nunit.org/)
- [FluentAssertions](https://fluentassertions.com/)
- [Moq](https://github.com/moq) 

# SpaceX API
The [SpaceX API](https://docs.spacexdata.com/?version=latest)  is a RESTful web service that provides data about SpaceX launches, including details. I integrate this API into my application, leveraging its endpoints for accessing information on upcoming and past launches, as well as the launch details for a specific launch.

# How to run locally

Open project with a Visual Studio and set up start multiple projects. Choose WebAPI and ReactApp.

# License

This project is licensed with the [MIT license](LICENSE).
