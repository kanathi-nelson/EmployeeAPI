# EmployeeAPI
The project is created using .NET 6 
The project uses Onion architecture arranged in the following structure:
<br/> <b> i.  EmployeeAPI.Data </b>   -This is the domain layer; This project is a class library containing the models - Employee model
<br/> <b>ii. EmployeeAPI.Repo  </b> - This is the Infrastructure layer; containing the DbContext and the Generic repository
<br/> <b>iii. EmployeeAPI.Service  </b> - This layer contains the business rules and the repositories that query data from the database
<br/> <b>iv. EmployeeAPI </b>   - This is the WEB API project- A basic .NET Web api project.

The project uses dependency injection to inject required services and to ensure the code is loosely coupled.
The repository pattern is used to ensure code reuse and clean code is produced.
