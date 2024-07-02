var builder = WebApplication.CreateBuilder(args);

// SERVICIOS
builder.Services.AddControllers();

var app = builder.Build();

// middlewares
app.UseHttpsRedirection();
app.UseAuthentication();
// controllers

app.MapControllers();


app.Run();
