using Ecommerce.Infrastructure;
using Ecommerce.Application;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure layer Dependencies
builder.Services.InfrastructureDependencies(builder.Configuration);

// Add Application layer Dependencies
builder.Services.ApplicationDependencies();

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger generator services
builder.Services.AddSwaggerGen(); // This line adds the Swagger services.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add CORS policy that allows all origins, methods, and headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure that the CORS middleware is called before Authorization and other middlewares
app.UseCors("AllowAll");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();