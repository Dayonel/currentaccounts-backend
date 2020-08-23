# CurrentAccounts API
CurrentAccounts API live version can be found here:
https://currentaccounts-api.herokuapp.com/swagger/index.html
![CurrentAccounts API](https://i.imgur.com/zdigOeS.png)

### Steps to execute project locally

#### 1. Download and install .NET Core SDK 3.1.201 or greater
https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.201-windows-x64-installer

#### 2. Run the project
Navigate to the project folder where the **CurrentAccounts.csproj** file is contained, for example:
![CurrentAccounts.csproj file](https://imgur.com/NADRtNF.png)

> C:\git\currentaccounts-backend\CurrentAccounts\CurrentAccounts

Open a console in project root and execute:

    dotnet run

![dotnet run](https://imgur.com/ph3xzDA.png)

#### 3. Swagger
The project has a swagger UI to test endpoints.
Is available in URL:
[https://localhost:5001/swagger](https://localhost:5001/swagger)

To test a endpoint, toggle the desired endpoint and click "Try it out"
![Try it our swagger button](https://imgur.com/3hA9pua.png)

When the API starts, it executes a hosted service to seed database with test data.
We can test the endpoints with customer ID(s) from 1 to 5 inclusive.
![Testing customer endpoint](https://imgur.com/3FzC56r.png)