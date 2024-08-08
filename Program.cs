using Employee_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Configure DbContext for MySQL
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25))));


builder.Services.AddCors(options => {

    options.AddPolicy("AllowAll",

        builder => {

            builder.AllowAnyOrigin()

                   .AllowAnyMethod()

                   .AllowAnyHeader();

        });

});

// Add controllers
builder.Services.AddControllers();

// Register Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
});

System.Diagnostics.Debug.WriteLine("message from program");

var app = builder.Build();
app.UseCors("AllowAll");
// Configure middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Use Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
});

app.MapControllers();



app.Run();
