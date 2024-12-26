#  CRUD Application with ASP.NET Core MVC
Description

This project is a CRUD (Create, Read, Update, Delete) application built with ASP.NET Core MVC. It connects to a SQL database to manage data efficiently and provides a user-friendly interface for basic data operations. The project demonstrates the implementation of the MVC design pattern, Entity Framework Core for database interaction, and Bootstrap for responsive UI design.

## Features

Create: Add new records to the database.

Read: View existing records with detailed information.

Update: Edit and update existing records.

Delete: Remove records from the database.

## SQL Database Integration: Utilizes Entity Framework Core for database operations.

Responsive UI: Designed with Bootstrap for mobile and desktop compatibility.

## Prerequisites

Ensure you have the following installed on your machine:

Visual Studio (2022 or later) with .NET Core workload

.NET SDK

SQL Server or a compatible SQL database

Git

Getting Started

Clone the Repository

# Clone the repository
''' # git clone https://github.com/Debitsme/ASP.Net-Crud-Application '''

# Navigate to the project directory
cd your-repo-name

Setup the Database

Open the project in Visual Studio.

Configure the database connection string in appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;"
  }
}

Apply migrations to create the database schema:

dotnet ef database update

Run the Application

Build and run the project:

dotnet run

Open your browser and navigate to https://localhost:5001 (or the URL shown in the terminal).

Usage

Creating Records

Navigate to the "Create" page using the Create New Item button.

Fill out the form and click "Submit" to add a new record.

Reading Records

View the list of records on the homepage.

Click "Details" to see more information about a specific record.

Updating Records

Click "Edit" next to the record you want to update.

Modify the fields as needed and click "Save".

Deleting Records

Click "Delete" next to the record you want to remove.

Confirm the deletion to permanently remove the record.

Project Structure

|-- Controllers
|   |-- ItemsController.cs
|
|-- Models
|   |-- Item.cs
|
|-- Views
|   |-- Items
|       |-- Create.cshtml
|       |-- Edit.cshtml
|       |-- Index.cshtml
|       |-- Details.cshtml
|       |-- Delete.cshtml
|
|-- appsettings.json
|-- Program.cs
|-- Startup.cs

## Key Files

ItemsController.cs: Contains logic for CRUD operations.

Item.cs: Defines the database model for the application.

Create.cshtml, Edit.cshtml, etc.: Razor views for the user interface.

Technologies Used

ASP.NET Core MVC: Framework for building web applications.

Entity Framework Core: ORM for database interactions.

SQL Server: Backend database.

Bootstrap: Frontend framework for responsive design.

Contributing

Fork the repository.

Create a new branch:

git checkout -b feature-name

Commit your changes:

git commit -m "Add feature description"

Push to the branch:

git push origin feature-name

Create a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

Acknowledgments

Microsoft Documentation

Entity Framework Core Documentation

Bootstrap Documentation
 
