var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();//para el plugin de actualizar las paginas
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mantenedor}/{action=Guardar}/{id?}");//se cambia la pagina principal de Home a Mantenedor y la accion de Index a Guardar
    //pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
