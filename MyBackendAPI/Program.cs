using api_cinema_challenge.EndPoints;
using MyBackendAPI.Data;
using MyBackendAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CinemaContext>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();           // Enables Swagger
    app.UseSwaggerUI();        // UI for Swagger
}


app.configureMovieEndpoint();
app.UseHttpsRedirection(); // Only enable HTTPS redirection in production
app.Run();
