using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configurar o Serilog para registrar em um arquivo
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Define o nível mínimo de log
    .WriteTo.File(@"logs\log.txt", rollingInterval: RollingInterval.Day) // Define o arquivo de log
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(); // Substitui o logging padrão pelo Serilog

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();