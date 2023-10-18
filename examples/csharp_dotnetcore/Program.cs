using CmacPartnerApi;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null).Services
    .AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}
app.UseCors(o => o
    .SetIsOriginAllowed(url => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.MapRoutes();

app.Run();