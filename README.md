## Student Management Application
A sample full-stack application with a backend __ASP.NET Core Web API__ project and a frontend __Blazor Web Assembly__ project.

![Student-](https://github.com/SaraRasoulian/DotNet-WebAPI-Blazor-Sample/assets/51083712/8a385730-3a8c-4444-82a2-c329d06c19df)


## Technology Stack
  -	ASP.NET Core Web API -v8
  - Entity Framework Core -v8
  - DDD (Domain-Driven Design)
  - TDD (Test-Driven Development)
  - BDD (Behavior-driven Development)
  - Clean Architecture
  - Clean Code
  - Repository Design Pattern
  - CQRS Design Pattern
  - Mediator Design pattern
  - PostgreSQL Database
  - Blazor WebAssembly -v8
  - Bootstrap -v5
  - Docker

#### Nuget Packages
  - __xUnit__ for unit, integration and acceptance testing
  - __Testcontainers__ for integration and acceptance testing
  - __SpecFlow__ for acceptance testing
  - __NSubstitute__ for mocking
  - __Bogus__ for fake data generating  
  - __MediatR__ for implementing mediator pattern
  - __FluentValidation__ for server-side validation
  - __Mapster__ for object mapping
  - __Blazor.Bootstrap__ for implementing user-interface


This repository is intended for demonstrating best practices in software development. In real-world applications, these practices should be selected based on the specific requirements of each project.


      
## Run with Docker

#### 1. Start with Docker compose

Run the following command in project directory:

```
docker-compose up -d
```

Docker compose in this application includes 4 services:

- Web API application will be listening at `http://localhost:5000`

- Blazor webAssembly application will be listening at `http://localhost:8080`

- Postgres database will be listening at `http://localhost:5433`

- PgAdmin4 web interface will be listening at `http://localhost:8000`


#### 2. Run the migrations

Open `StudentManagement.Server.sln` file in visual studio, then in package manager console tab, run:

```
update-database
```

This command will generate the database schema in postgres container.


---

Make sure Docker engine is running, before running integration and acceptance tests.

