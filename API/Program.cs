using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//Configure the HTTP request pipeline
app.MapControllers();

// Create a new scope for the application's services (dependency injection container)
// This ensures that scoped services like DbContext are disposed properly after use
using var scope = app.Services.CreateScope();

// Access the service provider (container) for resolving services like DbContext and Logger
var services = scope.ServiceProvider;

try
{
    // Get an instance of AppDbContext from the service provider
    // This is how we ask the dependency injection system for the database context
    var context = services.GetRequiredService<AppDbContext>();

    // Apply any pending migrations to the database
    // This automatically updates the database schema to the latest version
    await context.Database.MigrateAsync();

    // Run the seeding process to insert initial data into the database
    // This is usually some test or default data
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    // If an error occurs during migration or seeding, we catch the exception here

    // Get the logger service so we can log the error properly
    var logger = services.GetRequiredService<ILogger<Program>>();

    // Log the error with full details to help with debugging
    logger.LogError(ex, "An error occurred during migration and seeding the database.");

    // Also print the error message to the console for immediate visibility
    Console.WriteLine($"An error occurred during migration and seeding the database.: {ex.Message}");
}


app.Run();

