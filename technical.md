Note : Startup project should be ParkBee.Assessment.API project
Given project target framework was dotnetcore 2.2, I upgraded to dotnet 3.1 in order to build project need it.
-- dotnet build 
-- dotnet test

1.What architectures or patterns are you using currently or have worked on recently?

    - I used onion architecture for this assessment.Normally I am familiar with different arc. like onion,hexagonal,layered arch. etc.
    At the same time low level arcs. like CQRS and eventsourcing. In the assessment, we have 4 layer Domain,Infrastructure,Application and API
    Domain encapsulate only businesses and domain specific things.Application is responsible for handling use cases and uses domain and infra layers.
    Infrastructure is actually cross-cutting also know domain for some cases. Api is an entry point which only know infra. and application mostly.

2.What do you think of them and would you want to implement it again?

    - I would use event sourcing for history. I could save domain changes as event stream and I can project historical data through projection process.
    - There are a lot of edge cases in this assessment. I could write more unit test and integration tests as well.
    - I could touch UI part. I would have it.
    - There are some point that I could not make it clear. I mostly focused my OOP skills and development skills.

3.What version control system do you use or prefer?

    - Almost everytime I use git.As a branching model I would prefer custom branching model but similar with git flow.
 
4.What is your favorite language feature and can you give a short snippet on how you use it?
    
    - Tuples, pattern matching, record types, local functions, Async streams etc.

5.What future or current technology do you look forward to the most or want to use and why?

    - Kotlin maybe as a different stack. As a tech. I would drill down into Kafka stack.
    - Why kafka, I would explain little bit further. Kafka is partionated commit log so that it is not only messaging queueu
    At the same time, we can use kafka topics as meterial views. We can project different read models etc.

6.How would you find a production bug/performance issue? Have you done this before?

    - Yes, As we are developers we always look into performance,bugs and some enhancements about our systems.
    First of all, We need to have good monitoring,logging systems.and alarm mechanisms that if something goes wrong, we need to immediately notified by systems.
    - As a developer I would use RPM tools in order to monitor performance metrics and determine performance issues about systems especially
    about dependency issues,db queries, process memory and cpu consumptions and custom performance metrisc etc.


7.How would you improve the sample API (bug fixes, security, performance, etc.)?

    - I would delegate auth. part to application Gateway. GW can handle auth part and then route actual request to app.
    - In terms of performance, I would implement CQRS pattern for read model and command side. I would decompose into two procesesses that one is responsible for read model another one is responsible for use case handling
    which give us good decomposition on out system.
    - I would use secret management tool in order to increase security matters.
    - I would use ELK stack for logging and monitoring.
