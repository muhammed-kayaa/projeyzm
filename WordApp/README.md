# WordApp

## Project Overview
WordApp is a C# console application designed to manage user credentials and a vocabulary of words. The application utilizes Entity Framework for database interactions and provides a simple interface for user operations and word management.

## Project Structure
```
WordApp
├── src
│   ├── Models
│   │   ├── User.cs
│   │   └── Word.cs
│   ├── Data
│   │   └── AppDbContext.cs
│   ├── Program.cs
│   └── Services
│       └── UserService.cs
├── WordApp.csproj
└── README.md
```

## Features
- User management: Create, authenticate, and retrieve user information.
- Word management: Store and retrieve words in both English and Turkish, along with associated images.

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd WordApp
   ```
3. Restore the project dependencies:
   ```
   dotnet restore
   ```
4. Update the database connection string in `AppDbContext.cs` as needed.
5. Run the application:
   ```
   dotnet run
   ```

## Usage Guidelines
- Follow the prompts in the console to create a user or manage words.
- Ensure that the database is properly set up before running the application.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.