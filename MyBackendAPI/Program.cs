var builder = WebApplication.CreateBuilder(args);

// Configure CORS to allow requests from Swagger UI and other allowed origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .WithOrigins("http://localhost:5000", "https://localhost:5001") // Add the origins you're using
            .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
            .AllowAnyHeader()); // Allow any header
});

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

app.UseHttpsRedirection(); // Only enable HTTPS redirection in production

app.MapControllers();

app.Run();
