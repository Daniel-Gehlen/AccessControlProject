# Access Control API Project

![](/assets/Access%20Control%20API.webm)

## Summary
The Access Control API project is designed to manage restrictions for different categories of people accessing specific areas. It utilizes ASP.NET Core for the backend, with a simple HTML/JavaScript frontend for user interaction. This project incorporates CRUD operations, making it versatile for various access control scenarios.

## Installation Instructions

To create and run the Access Control API project, follow these steps in the terminal:

### Prerequisites
Make sure you have the following installed:
- [.NET SDK (8.0)](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/)
- [Visual Studio Code](https://code.visualstudio.com/) (optional, for IDE)

### Steps to Create the Project

1. **Create a new solution:**
   ```bash
   dotnet new sln -n AccessControlProject
   ```

2. **Create the API project:**
   ```bash
   dotnet new webapi -n AccessControlAPI
   ```

3. **Add the API project to the solution:**
   ```bash
   dotnet sln AccessControlProject.sln add AccessControlAPI/AccessControlAPI.csproj
   ```

4. **Create the Frontend project:**
   ```bash
   mkdir AccessControlFrontend
   cd AccessControlFrontend
   touch index.html script.js styles.css
   cd ..
   ```

5. **Install necessary packages (if applicable):**
   ```bash
   # If you plan to use any packages, you can add them to the AccessControlAPI
   cd AccessControlAPI
   dotnet add package [PackageName]
   ```

6. **Build the solution:**
   ```bash
   dotnet build AccessControlProject.sln
   ```

7. **Run the API project:**
   ```bash
   dotnet run --project AccessControlAPI
   ```

8. **Open the Frontend (in another terminal):**
   You can simply open the `index.html` in a web browser.

## Technologies Used
- **Backend:** ASP.NET Core 8.0 for building RESTful APIs.
- **Frontend:** HTML, JavaScript, and CSS for the user interface.
- **Database:** Entity Framework Core with SQL Server for data persistence.
- **Package Management:** NuGet for managing .NET packages.

## Directory Structure
```
AccessControlProject
├── AccessControlAPI
│   ├── AccessControlAPI.csproj
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Controllers
│   │   └── MainController.cs
│   ├── Models
│   │   └── Models.cs
│   ├── bin
│   ├── obj
│   └── Program.cs
├── AccessControlFrontend
│   ├── index.html
│   ├── script.js
│   └── styles.css
├── Access Control API.webm
└── AccessControlProject.sln
```

### Explanation of Directory Structure
- **AccessControlAPI/**: Contains the backend logic for managing access control, including models and controllers.
- **AccessControlFrontend/**: Holds the frontend files where users can interact with the API.
- **AccessControlProject.sln**: The solution file that groups the projects together.

## System Requirements
- **OS**: Windows, macOS, or Linux
- **.NET SDK**: Version 8.0 or higher
- **Database**: SQL Server or compatible database system for data storage.

## Case Study
### Scenario
In a corporate setting, the Access Control API can be employed to manage who can enter restricted areas. For instance, **employees** may access most areas, while **visitors** may be restricted from entering the **Data Center**.

### Implementation
1. **Predefined Categories**: People categories such as Employees, Visitors, and Services are predefined in the system.
2. **CRUD Operations**: Admins can create, read, update, and delete restrictions based on changing company policies or project requirements.
3. **User Interface**: The simple HTML interface allows easy interaction with the backend, enabling real-time updates to restrictions.

### Conclusion
This project effectively demonstrates how to implement a comprehensive access control system utilizing modern web technologies. The clean architecture and defined responsibilities make it a scalable solution for any organization needing to manage access rights.
