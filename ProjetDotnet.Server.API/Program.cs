using ProjetDotnet.Server.API;
using ProjetDotnet.Server.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Dossier à surveiller pour l'import du fichier XML généré aléatoirement
string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
string solutionRoot = Directory.GetParent(projectRoot).FullName;
string watchDirectory = Path.Combine(solutionRoot, "ProjetDotnet.Generation", "Import");
Console.WriteLine($"Dossier à surveiller : {watchDirectory}");

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