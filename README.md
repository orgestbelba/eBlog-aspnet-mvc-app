# eBlog ASP.NET MVC Blog Platform

eBlog is a simple blog platform built using ASP.NET Core MVC framework. It provides basic functionalities such as user authentication, post creation, and commenting. 
The project utilizes Entity Framework Core for data access, .NET Core 5 for development, Dependency Injection for managing dependencies, Identity Framework for user authentication, and Fluent API for configuring the database.

## Features

- **User Authentication**: Users can register and log in securely.
- **Post Management**: Users can create, edit, and delete blog posts.
- **Comment System**: Users can comment on posts, fostering interaction and engagement.
- **Future Development**:
  - **Admin Panel**: Implementing an admin panel for managing users, posts, and comments.
  - **Pagination**: Adding pagination for better navigation through posts.
  - **Email Notifications**: Introducing email notifications for various actions such as new comments on a post.

## Technologies Used

- **.NET Core 5**: The foundation of the application, providing a modern and cross-platform framework for development.
- **Entity Framework Core**: Used for data access and database management.
- **Dependency Injection**: Utilized for managing object dependencies and promoting loose coupling.
- **EntityBase Repository**: A generic repository pattern for common CRUD operations on entities.
- **Identity Framework**: For secure user authentication and authorization.
- **Fluent API**: Employed for configuring the database context and defining the relationships between entities.

## Getting Started

1. **Clone the Repository**: `git clone https://github.com/orgestbelba/eBlog-asp-mvc.git`
2. **Navigate to the Project Directory**: `cd eBlog-asp-mvc`
3. **Install Dependencies**: `dotnet restore`
4. **Set up the Database**: Ensure your connection string is configured correctly in `appsettings.json` and then run `dotnet ef database update` to apply migrations.
5. **Run the Application**: `dotnet run`
6. **Access the Application**: Open your browser and navigate to `https://localhost:5001` to start using the eBlog web app.
7. **Seeded database**: Upon running the application, seed data will automatically populate your database.
8. **Test Account**: Optionally, you can use the following credentials for initial login: (Email: user1@etickets.com; Password: Coding@1234?

## Contributing

Contributions are welcome! If you'd like to contribute to the project, please fork the repository and submit a pull request with your changes.
