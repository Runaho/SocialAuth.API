using System;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using SocialAuth.API.Extensions;

namespace SocialAuth.API.Endpoints;

public static class LoginPage
{
    public static async Task Handler(HttpResponse response, HttpContext httpContext, string? returnUrl = null)
    {
        response.Headers.ContentType = new string[] { "text/html" };

        var buttons = (await httpContext.GetExternalProvidersAsync()).Select(s => $"""
                    <div class="{s.Name.ToLower()}">
                        <button type="submit" name="provider" value="{s.Name}"><i class="fab fa-{s.Name.ToLower()}"></i>Sign in With {s.DisplayName}</button>
                    </div>
                    """);
        string html = GetHtml();
        html = html.Replace("{{guid}}", Guid.NewGuid().ToString());
        html = html.Replace("{{buttons}}", string.Join("", buttons));

        await response.WriteAsync(html);
    }

    public static string GetHtml()
    {
        try
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            //string[] resourceNames = thisAssembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream("SocialAuth.API.Template.LoginPage.html");
            using StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            return result;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
       
    }
}
