# Social Auth API

Social Auth API is a middleware service that allows users to authenticate through their social media accounts and saves the tokens and returned claims.
You can use this project that I wrote for my hobby project hosting provider, which I developed in my spare time, with peace of mind.

Since it is a very simple project, it is not a secure project, it is not tested and the logic may not be correct.
You can develop the project yourself and use it for your personal purposes, If you edit and contribute to the project, I can include it in the published repo.
You can't use only the logo and the name easyupload, I didn't remove them as an example for you.

![image](https://user-images.githubusercontent.com/16222645/210762700-909724eb-50e3-4bcb-8245-581a7443ade6.png)

## Requirements

To use Social Auth API, you will need the following:

- A client ID and secret for the desired social media provider(s)
- AspNet.Security.OAuth and Microsoft.AspNetCore.Authentication.Core libraries
- .Net Core 7 Minimal API

## Installation and Setup

![image](https://user-images.githubusercontent.com/16222645/210763079-861d93d5-2b40-43ce-8201-24b77e51d4a9.png)

1. Add your social media provider's client ID and secret to the project configuration section.
2. Modify the login page template at `Template/LoginPage.html` if desired.
3. If you add or remove an provider, the button will be automatically added/removed to the login page.
4. Build and run the project.

## Usage

Social Auth API has two endpoints:

1. `login`: This endpoint has both GET and POST handlers for authentication.
2. `user`: This endpoint returns claims for an authenticated user (example usage only).

## Documentation and Resources

- [AspNet.Security.OAuth library documentation](https://www.nuget.org/packages/AspNet.Security.OAuth/)
- [Microsoft.AspNetCore.Authentication.Core library documentation](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Core/)
- [.Net Core documentation](https://docs.microsoft.com/en-us/dotnet/core/)

## Contributors

Thank you to all the contributors of Social Auth API. If you'd like to contribute, please see the contribution guidelines.

Current contributors:
- [Runaho]
