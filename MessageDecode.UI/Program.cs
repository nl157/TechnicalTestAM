using MessageDecode.Services;
using MessageDecode.Services.Interfaces;
using MessageDecode.UI.Components;
using MessageDecode.UI.Properties.Options;
using MessageDecode.Validations;
using MessageDecode.Validations.Interfaces;
using MessageDecode.Validations.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddTransient<IDecoderService, DecoderService>();
builder.Services.AddTransient<IInputValidationBuilder, InputValidationBuilder>();
//builder.Services.AddTransient<IValidator<string>, Validator<string>>();

builder.Services.Configure<ErrorMessageOptions>(builder.Configuration.GetSection(ErrorMessageOptions.ErrorMessage));
builder.Services.Configure<ValidationOptions>(builder.Configuration.GetSection(ValidationOptions.Validation));

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
