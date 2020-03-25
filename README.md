# Solution structure
The Solution is divided in 3 main project types:
 - Domain
 - WebAPI
 - Shared classes

## Domain
The domain is structured in a DDD approach and here stands all the logic of a domain. All the domain logic should be done here (parameters validation, exception throwing, updates and creation of a class or a subclass)

## WebAPI
The WebAPI is the core of the applications it's structured following **CQRS** (Command-Query Responsability Segregation) pattern and it's divided in
- Controllers
- CommandHandlers
- QueryHandlers
- Repository

#### Controllers
The controller is the REST API where the front be doing its stuff, no logic here, just sending commands or queries using MediatR (a library that implements Mediator layer between controllers and Commands/Queries handlers) and logging exception. The API uses Swagger (NSwag library) to document the api and to easily test the methods by going at [controllerAddress]/swagger/index.html

### CommandHandlers
Here the magic happens. Everything that involves un update/save at database should happen here; and the cross-domain logic (eg: duplicated records) should be checked here, before creating and saving to the repository layer.

### QueryHandlers
We got the "Q" of CQRS here. So DB queries should be done here, and should NOT update records to the database (consider a separate user with only read permissions here) and should be indipendent (even techonologically, so using a different library, like dapper) from the Command side.

### Repository
Here you can access to the classes stored to the Database and (optionally) mapped using an ORM (like NHibernate or EntityFramework).

## Shared
Here there's everything that needs to be shared between projects (eg: interfaces that could be implemented in different projects). 

# How to start the project
Rebuild the project to get all the missing NuGet packages.
Select every .API project and set it as startup project, then change from IIS to the project (without IIS :poop:). Then right click on the solution and set every .API project to start, then start the project and here you go.

# Before changing anything
Read how the project is structured and follow the patterns and the project structure.