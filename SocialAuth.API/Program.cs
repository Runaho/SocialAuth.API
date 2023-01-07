using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using SocialAuth.API.Endpoints;
using SocialAuth.API.Records;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
services.AddAuthentication("cookie").AddCookie("cookie", o =>
{
    o.LoginPath = "/login";
}).AddGoogle(options =>
{
    options.ClientId = configuration["GoogleClientId"];
    options.ClientSecret = configuration["GoogleClientSecret"];
    options.SaveTokens = true;
}).AddMicrosoftAccount(options =>
{
    options.ClientId = configuration["MicrosoftClientId"];
    options.ClientSecret = configuration["MicrosoftClientSecret"];
    options.AuthorizationEndpoint = configuration["MicrosoftAuthorizationEndpoint"];
    options.TokenEndpoint = configuration["MicrosoftTokenEndpoint"];
    options.SaveTokens = true;
}).AddApple(options =>
{
    options.ClientId =  configuration["AppleClientId"];
    options.KeyId = configuration["AppleKeyId"];
    options.TeamId = configuration["AppleTeamId"];
    options.GenerateClientSecret = true;
    options.PrivateKey = (keyId, _) => Task.FromResult(configuration["AppleP8"].AsMemory());
});

services.AddAuthorization();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapGet("/", LoginPage.Handler);
app.MapPost("/login", Login.Handler);
app.MapGet("/login", Login.GetHandler);


app.MapGet("/user", async (HttpContext ctx) =>
{
    var datas = ctx.User.Claims.Select(s => new { s.Type, s.Value }).ToList();
    string accessToken = await ctx.GetTokenAsync("access_token");
    string idToken = await ctx.GetTokenAsync("id_token") ?? string.Empty;
    var userDetails = new UserDetails(datas, accessToken, idToken);
    return userDetails;
});

app.Run();
