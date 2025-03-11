using ProjetDotnet.Server.API;
using ProjetDotnet.Server.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Dossier à surveiller pour l'import du fichier XML généré aléatoirement
string watchDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Import");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new FileWatcherService(watchDirectory));

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