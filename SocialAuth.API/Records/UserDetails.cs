using System;
using System.Text.Json.Serialization;

namespace SocialAuth.API.Records;

public record UserDetails(object UserClaims, string AccessToken, string IdToken)
{
}

