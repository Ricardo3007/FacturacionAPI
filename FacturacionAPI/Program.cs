using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Repository;
using FacturacionAPI.Service.Contract;
using FacturacionAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefatultConnectionString");

// Agrega servicios al contenedor
builder.Services.AddSingleton<IClienteRepository>(new ClienteRepository(connectionString));
builder.Services.AddSingleton<IProductoRepository>(new ProductoRepository(connectionString));
builder.Services.AddSingleton<IFacturaRepository>(new FacturaRepository(connectionString));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();

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

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:4200") // Reemplaza con la URL de tu aplicación Angular
          .AllowAnyHeader()
          .AllowAnyMethod();
});

app.Run();
