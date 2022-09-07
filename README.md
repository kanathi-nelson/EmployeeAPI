# EmployeeAPI
The project is created using .NET 6 
The project used Onion architecture arranged in the following structure:
i.  EmployeeAPI.Data   - This project is a class library containing the models - Employee model
ii. EmployeeAPI.Repo  - This is the Infrastructure layer; containing the DbContext and the Generic repository
iii. EmployeeAPI.Service  - This layer contains the business rules and the repositories that query data from the database
iv. EmployeeAPI  - This is the WEB API project- A basic .NET Web api project.

The project uses dependency injection to inject required services and to ensure the code is loosely coupled.
The repository pattern is used to ensure code reuse and clean code is produced.
