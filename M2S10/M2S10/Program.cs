using M2S10.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionar dependências de repositorios
builder.Services.AddScoped<ArtistaRepository>((service) => new ArtistaRepository());
builder.Services.AddScoped<MusicaRepository>((service) => new MusicaRepository());
builder.Services.AddScoped<AlbumRepository>((services) => new AlbumRepository());

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
