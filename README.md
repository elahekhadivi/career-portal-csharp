# career-portal-csharp
career-portal-csharp is a job search portal for job seekers and recruiters to connect on one common platform.
●	Developed multi-layer web application including Repository layer, Pocos Layer, Business logic layer and API layer.

Project Architecture: Repository Layer, POCOs Layer, Business Logic Layer, API Layer, UI 

Technologies Used: ASP.Net, C#, .Net Core, MS SQL Server 2012, ADO.NET, Entity Frameworks, LINQ, REST WEB API, RPC standard (using gRPC libraries), GitHub

API Layer
The API layer is the connection point for client-side system to interact with the repository. 
This layer expose two sets of endpoint connectors. Those endpoints correspond to the REST (NET’s Web API libraries) and RPC (gRPC libraries) standards.

Business Logic Layer
The Business Logic Layer ensures that the data passed to the API is valid from a business perspective.
Classes in this layer have constructors that take an interface representing the repository layer.
Utilizing dependency inversion to provide an implementation of the repository layer demonstrate this powerful technique.

POCOs Layer
The POCOs (Plain Old C# Objects) layer acts as a bridge between the relational database (MS SQL) and
the object-oriented programming structures (C#). The POCOs are classes instantiated in memory that
store information either on its way from the database to the client or from the client on its way to the
database from the client.

Repository Layer
The Repository layer acts as a broker between the persistent storage (relational) and the object (code) layers. 
There are two implementations of the repository layer both of which define a common interface.
The common interface serves as a mechanism to inject either of those implementations.
