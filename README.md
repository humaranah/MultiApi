# MultiApi

MultiApi is a modular boilerplate for ASP.NET Core Web Api using best practices and DDD design.

## Project Structure

MultiApi uses DDD design, so the solution is structured in three main component folders inside of `src` folder:

- **Domain**: Contains all the Domain components such as Entities, Models, Model validations, etc.
- **Infrastructure**: Contains all the service logic of the application.
- **Presentation**: Contains all the Presentation logic such as Controllers and related components.

Each component folder has an `Abstractions` project, were it will have the common interfaces and basic components to all layer projects.

MultiApi has also a `test` folder for XUnit test cases.

The project structure is the following:

- **`[Solution Root]`**
  - **src**
    - Domain
      - **`MultiApi.Domain.Abstractions`**: *Interfaces and common objects for Domain layer*
      - **`MultiApi.Domain.WeatherForecast`**: *Example Domain project*
    - Infrastructure
      - **`MultiApi.Infrastructure.Abstractions`**: *Interfaces and common objects for Infrastructure layer*
      - **`MultiApi.Infrastructure.WeatherForecast`**: *Example Infrastructure project*
    - Presentation
      - **`MultiApi.Application`**: *Application facade project*
      - **`MultiApi.Module.Abstractions`**: *Interfaces and common objects for modules*
      - **`MultiApi.Module.WeatherForecast`**: *Example module project*
    - **`MultiApi.ApplicationHost`**: *Main project*
  - **test**
    - Infrastructure
      - **`MultiApi.Infrastructure.WeatherForecast.Tests`**: *Example test project*

## Dependency Injection

MultiApi uses the default [ServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection?view=dotnet-plat-ext-3.1) container that comes with ASP.NET Core for IoC, so all the services are registered and can be accessed from it.

## Logging

MultiApi uses [Serilog](https://github.com/serilog/serilog-aspnetcore) as default logging component.

## Module integration

When application starts, MultiApi loads all the `MultiApi.Module.*` projects and executes their configurator interfaces if theese have been implemented:

- `IModuleServicesConfigurator`: Provides a method to register the required services of the method to the container.
- `IModuleConfigurator`: Provides a method to configure the required services when the container is built.

Theese interfaces are located in `MultiApi.Module.Abstractions` project.

## License

MultiApi is licenced under the `MIT License`, so you can feel free to fork and use it in your public and private projects :).
