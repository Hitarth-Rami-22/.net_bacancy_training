using WebApplication1;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();


// Register FileService for Dependency Injection
builder.Services.AddScoped<IFileService, FileService>();
// Load city restriction from appsettings.json
builder.Services.Configure<WeatherSettings>(builder.Configuration.GetSection("WeatherSettings"));


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


Console.WriteLine("API is running...");
app.Run();
