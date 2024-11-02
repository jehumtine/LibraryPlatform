using LibraryPlatform.Controllers;
using LibraryPlatform.Controllers.Authentication;
using LibraryPlatform.Controllers.LibraryStaff;
using LibraryPlatform.Controllers.Loan;
using LibraryPlatform.Controllers.Stats;
using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;
using IAuthenticationService = Microsoft.AspNetCore.Authentication.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LibraryDbConnection")));
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ILibraryStaffService, LibraryStaffService>();
builder.Services.AddScoped<IStatsService, StatsService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LibraryContext>();
    var seeder = new BookSeeder(context);
    await seeder.SeedAsync();  // Seeding the books
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API");
    });
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();

