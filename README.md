# eBlog ASP.NET MVC App

This project is a simple yet functional blog platform developed using ASP.NET Core, MVC, and Entity Framework Core. It offers essential functionalities for users, including sign-up and login features using Identity Framework for authentication.
Users can easily create, view, and comment on posts within the system. The platform's straightforward design ensures a seamless experience for both writers and readers. 
Additionally, a search bar is provided for efficient navigation, allowing users to find specific posts with ease.

In summary, this project provides a practical foundation for a fully functional blog environment, prioritizing functionality over complex features.

## Installation

To run the project:

- Update the DefaultConnectionString in appsettings.json to match your database connection details.
- Open the Package Manager Console and create a new migration by executing the command Add-Migration InitialMigration, then apply the migration by executing Update-Database.
- Upon running the project, seed data will automatically populate your database.
- Optionally, you can use the following credentials for initial login:
  - Email: user1@etickets.com
  - Password: Coding@1234?
