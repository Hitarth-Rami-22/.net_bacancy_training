using WebApplication2.Controllers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Simple CORS



app.UseErrorHandalingMIddleware();


app.UseLogRequest();





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
