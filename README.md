# HireMe - Job Portal

HireMe is a comprehensive job portal platform designed to connect job seekers with potential employers. It facilitates the posting and application process for jobs, aiming to streamline the recruitment process and enhance employment opportunities.

## Features

- **Job Posting:** Employers can post job vacancies with detailed descriptions, requirements, salary range, and deadlines.
- **Job Application:** Job seekers can search for jobs, view job details, and apply directly through the portal.
- **Dynamic Filtering and Search:** Users can filter jobs by type, location, salary range, and more, ensuring they can find positions that match their qualifications and preferences.
- **User Profiles:** Both job seekers and employers can create and manage their profiles, showcasing qualifications, company information, and job listings.

## Getting Started

### Prerequisites

- .NET Core SDK (version specified in project)
- An IDE (Visual Studio, VS Code, or any compatible IDE)
- SQL Server or another database supported by Entity Framework Core
###
### Installation
**Download project file:**
```bash
https://github.com/Hadiya24/HireMe/
```

2. **Navigate to the project directory**
```bash
cd HireMe
```
3. **Restore dependencies**
```bash
dotnet restore
```
4. **Set up the database**
Update the connection string in appsettings.json to match your database configuration. Then, apply migrations to create the database schema:
```bash
dotnet ef database update
```
5. **Run the application**
```bash
dotnet run
```
The application will start, and you can access it through your web browser at http://localhost:5000 by default.
