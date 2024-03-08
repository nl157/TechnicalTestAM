using MessageDecode.Services;
using MessageDecode.Services.Interfaces;
using MessageDecode.UI.Components;
using MessageDecode.UI.Properties.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddTransient<IDecoderService, DecoderService>();
builder.Services.Configure<ErrorMessageOptions>(builder.Configuration.GetSection(ErrorMessageOptions.ErrorMessage));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
