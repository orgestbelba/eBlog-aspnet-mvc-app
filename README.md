# eBlog-aspnet-mvc-app
This project is a straightforward blog platform developed using ASP.NET Core, MVC, and Entity Framework Core. 
It provides basic yet essential functionalities for users, allowing them to sign up or log in using Identity Framework for authentication.

Users can seamlessly create, view, and comment on posts within the system. 
The platform's simplicity ensures an uncomplicated experience for both writers and readers. 
The inclusion of a search bar facilitates easy navigation, enabling users to find specific posts efficiently.

In essence, this project serves as a practical foundation for a functional blog environment, emphasizing functionality over elaborate features.

To run the project you need to:
 1. Change DefualtConnectionString @appsetting.json to yours.
 2. Open Package Manager Console and create a new migration (Add-Migration InitialMigration then update-database)
 3. There are currently some seed data that will populate your database once you run the project.
 4. You can optionally use these credentials for inital log in (e-mail: user1@etickets.com ; password: Coding@1234?)
