# Demo App
Purpose of this application is just to show my skillset.

This application has been built using Event Sourcing Architecture.

# __Folder Structure__
- deployments: include docker-compose file to setup eventstore db.
- framework: includes implementation that will be shared and imported later by applications.
- Usermanagement which includes actual implementation.

### UserManagement
Has two sides
1) Rest API which has been built with .net 6 and will receive different commands and pass it for processing.
2) Projector which is background service will listen to events emitted by eventstore db and construct to state of objects by applying events until the state of application will be created.

### Architecture
This application has composed of different techniques like
1) Domain Driven Design.
2) CQRS
3) Event Sourcing
4) Good Seperation of concerns, code goes to where they belong
5) Dependency injection principle to make a good amount of loose coupling.
6) Repository pattern

### Technologies used
1) .Net6
2) C#
3) EventStoreDB
4) Autofac dependency injection framework
