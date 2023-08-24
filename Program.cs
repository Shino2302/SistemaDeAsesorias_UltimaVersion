using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Datos.Implementacion;
using SistemaDeAsesorias.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGenericDatos<Grupo>, GrupoDatos>();
builder.Services.AddScoped<IGenericDatos<Alumno>, AlumnoDatos>();
builder.Services.AddScoped<IGenericDatos<CuatriCarrera>, CuatriCarreraDatos>();
builder.Services.AddScoped<IGenericDatos<Carrera>, CarreraDatos>();
builder.Services.AddScoped<IGenericDatos<Asesor>, AsesorDatos>();
builder.Services.AddScoped<IGenericDatos<TipoUsuario>, TipoUsuarioDatos>();
builder.Services.AddScoped<IGenericDatos<TipoAsesoria>, TipoAsesoriaDatos>();
builder.Services.AddScoped<InterMultiDatos<ConsultaGrupoModel>, GrupoMultiTabDatos>();
builder.Services.AddScoped<InMultiHorario<HorarioPorAsesor>, HorarioDatos>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ConsultaAsesoria}/{action=Listar}/{id?}");

app.Run();
