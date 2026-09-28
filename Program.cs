using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SoporteAurora.Datos;
using SoporteAurora;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<SoporteContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext"))
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Myapp", policyBuilder=>{
    policyBuilder.WithOrigins();
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyMethod();
    policyBuilder.AllowCredentials();
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseCors("Myapp");
app.MapGet("/", () => Results.Redirect("/scalar/v1"));
app.MapControllers();


app.Run();

