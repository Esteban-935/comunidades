using Comunidades.Data;
using Comunidades.Data.Models;
using Comunidades.Services;
var builder = WebApplication.CreateBuilder(args);

//Cors
var MyOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyOrigins, policy =>
    {
        policy.WithOrigins("*");
        policy.AllowAnyHeader();
        policy.WithMethods("GET", "POST", "PUT", "DELETE");
    });
});

//DBcontext
builder.Services.AddSqlServer<MembranaComunidadesBDContext>(builder.Configuration.GetConnectionString("ComundadesConnection"));

//Services layer
builder.Services.AddScoped<ReporteService>();
builder.Services.AddScoped<PeriodoService>();
builder.Services.AddScoped<MeseService>();
builder.Services.AddScoped<DetallePoblacionService>();
builder.Services.AddScoped<FormularioService>();
builder.Services.AddScoped<ConceptoService>();
builder.Services.AddScoped<CatalogoPoblacionService>();
builder.Services.AddScoped<AreaService>();
builder.Services.AddScoped<ConfiglocalService>();
builder.Services.AddScoped<ComunidadeService>();
builder.Services.AddScoped<DistritoService>();
builder.Services.AddScoped<EstatusService>();
builder.Services.AddScoped<LugaresservicioService>();
builder.Services.AddScoped<NombramientoService>();
builder.Services.AddScoped<RedeService>();
builder.Services.AddScoped<ServidoreService>();
builder.Services.AddScoped<TerritorioService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//cors
app.UseCors(MyOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
