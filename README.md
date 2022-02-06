Run Migrations
- Set as Startup Project WebApi
- Package Manager Console => Default project waproject.Data
- Add-Migration InitialCreate -Context ApplicationDbContext
- Package Manager Console => Default project waproject.Data
- Add-Migration InitialCreate -Context AuthDbContext
- Update-Database Or start the application with docker-compose