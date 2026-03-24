# BlogApp

A modern, responsive blog application built with ASP.NET Core Razor Pages and Bootstrap 5.

## Features

- 📝 **Full CRUD Operations**: Create, Read, Update, and Delete blog posts
- 📱 **Responsive Design**: Mobile-first layout using Bootstrap 5
- 🗄️ **Entity Framework Core**: SQL Server database integration
- ✅ **Comprehensive Testing**: Unit tests and integration tests with xUnit
- 🎨 **Modern UI**: Clean, intuitive interface with Bootstrap components

## Project Structure

```
BlogApp/
├── src/
│   ├── BlogApp/                  # Main application
│   │   ├── Pages/
│   │   │   ├── Index.cshtml      # Home page
│   │   │   ├── Privacy.cshtml    # Privacy policy
│   │   │   └── Posts/
│   │   │       ├── Index.cshtml      # Blog post listing
│   │   │       ├── Create.cshtml     # Create post form
│   │   │       ├── Edit.cshtml       # Edit post form
│   │   │       ├── Details.cshtml    # View post details
│   │   │       └── Delete.cshtml     # Delete confirmation
│   │   ├── Models/
│   │   │   └── Post.cs           # Post model
│   │   ├── Data/
│   │   │   └── BlogAppContext.cs # EF Core database context
│   │   ├── wwwroot/              # Static files (CSS, JS, images)
│   │   ├── appsettings.json      # Configuration
│   │   └── Program.cs            # Application startup
│   └── BlogApp.Tests/            # Unit and integration tests
│       ├── UnitTest1.cs          # Post CRUD unit tests
│       └── SeedDataTests.cs      # Seed data integration tests
├── agents/                       # Agent definitions for task management
├── rules/                        # Business rules documentation
└── Tasks.md                      # Development task tracking

```

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later
- SQL Server (LocalDB or Express)
- Visual Studio Code or Visual Studio

### Installation

1. **Clone the repository**
   ```bash
   cd c:\projects\blogapp
   ```

2. **Navigate to the solution**
   ```bash
   cd src
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Apply database migrations**
   ```bash
   cd BlogApp
   dotnet ef database update
   ```
   This will create the database and seed it with initial posts.

5. **Run the application**
   ```bash
   dotnet run
   ```
   The application will be available at `https://localhost:5001`

### Running Tests

From the `src` directory, run:
```bash
dotnet test
```

This runs all unit and integration tests. To run tests for a specific project:
```bash
dotnet test BlogApp.Tests/BlogApp.Tests.csproj
```

## Post Model

The `Post` model represents a blog post with the following properties:

```csharp
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedDate { get; set; }
}
```

### Validation Rules

- **Title**: Required, max 100 characters
- **Content**: Required
- **Author**: Required, max 50 characters
- **CreatedDate**: Defaults to current date/time

## API Endpoints

### Posts

All endpoints in this API are Razor Pages and return HTML responses. They follow RESTful conventions.

#### List All Posts
- **URL**: `/Posts`
- **Page**: `Pages/Posts/Index.cshtml`
- **HTTP Method**: GET
- **Description**: Displays a grid view of all blog posts with previews
- **Response**: HTML page with responsive card layout
- **Query Parameters**: None

**Example**: `https://localhost:5001/posts`

#### View Post Details
- **URL**: `/Posts/Details/{id}`
- **Page**: `Pages/Posts/Details.cshtml`
- **HTTP Method**: GET
- **Description**: Displays the full content of a single post
- **Response**: HTML page with complete post information
- **Route Parameters**:
  - `id` (int): The post ID

**Example**: `https://localhost:5001/posts/details/1`

#### Create Post (Display Form)
- **URL**: `/Posts/Create`
- **Page**: `Pages/Posts/Create.cshtml`
- **HTTP Method**: GET
- **Description**: Displays the form to create a new post
- **Response**: HTML form page
- **Query Parameters**: None

**Example**: `https://localhost:5001/posts/create`

#### Create Post (Submit)
- **URL**: `/Posts/Create`
- **Page**: `Pages/Posts/Create.cshtml`
- **HTTP Method**: POST
- **Description**: Submits a new post to the database
- **Request Body**:
  ```
  Title=My First Post
  Content=This is the content of my post
  Author=John Doe
  ```
- **Response**: Redirect to posts list on success
- **Validation**: Title, Content, and Author are required

#### Edit Post (Display Form)
- **URL**: `/Posts/Edit/{id}`
- **Page**: `Pages/Posts/Edit.cshtml`
- **HTTP Method**: GET
- **Description**: Displays the form to edit an existing post
- **Response**: HTML form page with current post data
- **Route Parameters**:
  - `id` (int): The post ID

**Example**: `https://localhost:5001/posts/edit/1`

#### Edit Post (Submit)
- **URL**: `/Posts/Edit/{id}`
- **Page**: `Pages/Posts/Edit.cshtml`
- **HTTP Method**: POST
- **Description**: Updates an existing post
- **Request Body**:
  ```
  Id=1
  Title=Updated Title
  Content=Updated content
  Author=Jane Doe
  CreatedDate=2023-01-01T12:00:00
  ```
- **Response**: Redirect to posts list on success
- **Validation**: Title, Content, and Author are required

#### Delete Post (Display Confirmation)
- **URL**: `/Posts/Delete/{id}`
- **Page**: `Pages/Posts/Delete.cshtml`
- **HTTP Method**: GET
- **Description**: Displays a confirmation page before deleting a post
- **Response**: HTML confirmation page with post summary
- **Route Parameters**:
  - `id` (int): The post ID

**Example**: `https://localhost:5001/posts/delete/1`

#### Delete Post (Confirm)
- **URL**: `/Posts/Delete/{id}`
- **Page**: `Pages/Posts/Delete.cshtml`
- **HTTP Method**: POST
- **Description**: Permanently deletes a post from the database
- **Request Body**:
  ```
  Id=1
  ```
- **Response**: Redirect to posts list on success
- **Warning**: This operation is permanent and cannot be undone

## UI/UX Features

### Responsive Design
- Mobile-first approach with Bootstrap 5 breakpoints
- Adaptive navigation bar with hamburger menu on small screens
- Card-based layout for post listings
- Touch-friendly buttons and controls

### Navigation
- Primary navigation bar with links to Home, Blog Posts, and Privacy
- Breadcrumb-style links for back navigation
- Contextual action buttons (Create, Edit, Delete)

### Post Listing
- Posts displayed as responsive cards in a grid
- Content preview with truncation (first 100 characters)
- Author and creation date information
- Quick action buttons for Details, Edit, and Delete

### Form Pages
- Clean, centered form layouts
- Inline validation feedback
- Clear success and error states
- Helpful placeholder text

### Details Page
- Full-width post content display
- Author and publication date prominence
- Related action buttons (Edit, Back to List)

## Database

### Connection String

The application uses SQL Server with LocalDB by default. The connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### Migrations

To create new migrations after changing the model:

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Seed Data

The application includes initial seed data with 3 sample posts. This is applied automatically when the database is created or updated.

## Testing

### Unit Tests (`UnitTest1.cs`)

Tests for Post CRUD operations:

- `CreatePost_ShouldAddPostToDatabase`: Verifies post creation
- `ReadPost_ShouldRetrievePostFromDatabase`: Verifies post retrieval
- `UpdatePost_ShouldModifyPostInDatabase`: Verifies post update
- `DeletePost_ShouldRemovePostFromDatabase`: Verifies post deletion

### Integration Tests (`SeedDataTests.cs`)

Tests for seed data functionality:

- `SeedData_ShouldContainInitialPosts`: Verifies 3 posts are seeded
- `SeedData_ShouldHaveCorrectAuthors`: Verifies seed data integrity

### Test Infrastructure

- Uses in-memory database for isolated, fast tests
- Each test gets a unique database instance
- No external dependencies or database setup required
- Async/await patterns for testing async code

## Development

### Technology Stack

- **Framework**: ASP.NET Core 10.0
- **UI Framework**: Bootstrap 5
- **ORM**: Entity Framework Core 10.0.5
- **Database**: SQL Server (LocalDB)
- **Testing**: xUnit 2.9.3

### Project Files

- `BlogApp.csproj`: Main application project file
- `BlogApp.Tests.csproj`: Test project file
- `BlogApp.slnx`: Solution file

### Code Quality

- Follows Microsoft C# coding standards
- Uses Entity Framework Core for data access
- Implements async/await for responsive operations
- Includes comprehensive input validation

## Configuration

### appsettings.json

Configuration file for the application:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogAppDb;..."
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Troubleshooting

### Database Connection Issues

If you encounter database connection errors:

1. Verify SQL Server is running
2. Check the connection string in `appsettings.json`
3. Run `dotnet ef database drop --force` to reset the database
4. Run `dotnet ef database update` to recreate it

### Port Already in Use

If port 5001 is already in use:

1. Run with a different port: `dotnet run --urls https://localhost:5002`
2. Or modify `launchSettings.json`

### Build Errors

If you encounter build errors:

1. Clean the solution: `dotnet clean`
2. Restore packages: `dotnet restore`
3. Rebuild: `dotnet build`

## Contributing

To contribute to this project:

1. Review the Tasks.md file for planned work
2. Follow the ASP.NET Core coding conventions
3. Write tests for new features
4. Test all CRUD operations

## Future Enhancements

See `Tasks.md` for planned features:

- Frontend: Additional Bootstrap templates and styling
- DevOps: GitHub Actions CI/CD pipeline
- Security: OWASP security scanning
- Performance: Database optimization and caching

## License

This project is part of the BlogApp development initiative.

## Contact

For questions or issues, please review the Rules.md and agent definitions in the `agents/` directory.

---

**Last Updated**: March 24, 2026
