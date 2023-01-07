using System;
using Microsoft.AspNetCore.Http;
using SocialAuth.API.Extensions;

namespace SocialAuth.API.Endpoints;

public static class Login
{
    public static async Task<IResult> Handler(string auth, HttpContext ctx)
    {
        string provider = ctx.Request.Form["provider"].ToString();
        if (string.IsNullOrEmpty(provider))
            return Results.NotFound();

        var providers = await ctx.GetExternalProvidersAsync();
        if (providers.Any(w => w.Name == provider))
            return Results.Challenge(authenticationSchemes: new List<string>() { providers.First(w => w.Name == provider).Name });

        return Results.NotFound();

    }

    public static IResult GetHandler(HttpResponse response, HttpContext httpContext, string? returnUrl = null)
    {
        if (returnUrl != null)
        {
            return Results.Redirect(returnUrl);
        }

        return Results.NotFound();
    }

}

