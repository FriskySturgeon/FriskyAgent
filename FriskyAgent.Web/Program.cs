using FriskyAgent.Web.Components;
using FriskyAgent.Bll.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Читаем ключ из конфигов / user-secrets
var openAiKey = builder.Configuration["OpenAI:ApiKey"]
                ?? throw new InvalidOperationException("OpenAI:ApiKey не задан");

// Регистрируем сервис и сразу настраиваем HttpClient
builder.Services
    .AddHttpClient<IOpenAiService, OpenAiService>(client =>
    {
        client.BaseAddress = new Uri("https://api.openai.com/");
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", openAiKey);
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
