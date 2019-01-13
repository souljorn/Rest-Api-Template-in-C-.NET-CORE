## Rest API Connected to MySql Database Performing Basic CRUD Operations

#### Development 
A Restful ApI was created using the ASP .NET Core framework in C# as a proof of concept to receive incoming  HTTP request and to return HTTP responses to the sender. The requests and responses are formatted as JSON when appropriate. The Rest API is pointed to a local instance of a mysql database with a single table to verify functionality. 
#### Consider the following sources
- [Building ASP .Net  Core Restful Api Tutorial Lynda.com -Sign in with UF domain, ufl.edu](https://www.lynda.com/ASP-NET-Core-MVC-tutorials/power-RESTful-APIs/753926/787036-4.html)
- [Setting up the entity model with Mysql](https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio)
- [Setting up the Entity Framework with Repository](https://code-maze.com/net-core-web-api-ef-core-code-first/)

---

## ANALYSIS AND DEVELOPMENT 

### Structure of RestAPI in C#

#### Program Main Entry Point
> **Files:** program.cs

> **Description:** Very simply the main entry point for the entire application . 

#### Startup Configurations
> **Files:** startup.cs

> **Description:** This is where all the services such as the Database, Routing, and DataRepository 
> configurations are injected. This is also where the application can decide between development 
> and production configurations. These configurations are written in launchsettings.json and 
> appsettings.json then injected in the startup.cs file. 

#### Configuration Files
> **Files:**    appsettings.json, appsettings.Development.json, launchsettings.json

> **Description:** This is where the database connection strings are written and what ports the 
> services are run on and how to set the configurations between development and production.

#### Model
> **Files:** model.cs

> **Description:** This is where the shape of the employee entity is defined. This is the model of the data that the 
> database and all layers expect to see. This is where the first definition of the 
> Schema needs to be defined outside of the database. 

#### Data Repository Interface 
> **Files:** IDataRepository.cs

> **Description:**  This is the generic interface which is extended for each Entity Class such as 
> Employee. This  defines all the functions that must be implemented in each Data Repository.

#### Data Repository for Employees
> **Files:** EmployeeManager.cs

> **Description:**  This is where the Data Repository Interface class
> is implemented for the Employee Entities. This is where the Crud operations are actually defined. 
> They rely on the Entity Framework objects defined in the model.

#### Controller for Employee
> **Files:** EmployeeController.cs

> **Description:** Controller handles the http requests to perform CRUD operations. Any  
> interaction with database coming from the controller are handled by the Data Repository. This 
> prevents the API endpoints from having to directly interact with the database. Also it allows the 
> database layer to be abstracted from the Rest Api layer. This helps with decoupling, for example, 
> when one might want to change databases, or data from the database is supplemented from 
> somewhere else.

#### Filters for Bad Api Requests
> **Files:** JsonExceptionFilter.cs, ApiError.cs

> **Description:**  Middleware filter for API errors that filters out Api errors and return a JSON object with an explicit 
> error and a stack trace, instead of a generic HTML response which has no useful data. ApiError.cs descibes the shape of 
> the error message returned. 

---

### Plugins Needed to Run Program(Might need to install manually through Plugins)
- EntityFramework(6.2.0)
- Microsoft.AspNetCore.App(2.1.1)
- MySql.Data(8.0.13)
- Pomelo.EntityFramework.MySql(2.1.4)

---

### Installation and Running Locally
- Install a local instance of MySql through MAMP or other means
- Setup a Schema that matches the model (Can easily be done in My PHP Admin, Console, or Other SQL tooling) :
> int ID 
> varchar Name 
> int Age 
> varchar Position 
> float Salary 
- Change the configurations in appsettings.json for the connection string to the database to point to your local instance of the database :
> ` "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=8889;database=TestDatabase;uid=root;password=root"
  }`
- Run the .Net .Core Application
- Test the Endpoints below using Postman or other HTTP Request tool of your choice

---

### Example Http Request for p.o.c. Rest Api
#### Use Postman to send Http requests to the Rest Api
#### Get All Employees
Type of Request: Get
URL: https://localhost:5001/Employee/

#### Get a Single Employee
Type of Request: Get
URL:: https://localhost:5001/Employee/id

#### Add an Employee
Type of Request: Post
URL: https://localhost:5001/Employee/
Body: {
"id" : "2",
"name" : "Dave Chapelle",
"age" : "45",
"position" : "Actor",
"salary" : "23423423"
}

#### Update an Employee
Type of Request: Put
URL: https://localhost:5001/Employee/id
Body: {
"id" : "2",
"name" : "Dave Chapelle",
"age" : "45",
"position" : "Actor",
"salary" : "23423423"
}

#### Delete an Employee
Type of Request: Delete
URL: https://localhost:5001/Employee/id

---

## TESTS
|Given|When|Then|
|---|---|---|
|Given a working API | Make a HTTP GET request to /Employee/ |Returns all Employees|
|Given a working API | Make a HTTP GET request to /Employee/id |Returns Employee with id|
|Given a working API | Make a HTTP POST request to /Employee/ |Creates new employee|
|Given a working API | Make a HTTP PUT request to /Employee/id |Updates Employee with id|
|Given a working API | Make a HTTP DELETE request to /Employee/id |Deletes Employee with id|
