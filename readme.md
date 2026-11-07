Get A New Password.com
=========

Get a new password is a personal project to build a unit tested website and api in a list of web languages to better understand their different limitations and strengths.

Requirements
-------------------

The sites must contain the following functionality:
 - Unit tested functionality that correctly generates a Correct-Horse-Battery-Staple type password.
 - Website to display password.
 - Rest API that returns both JSON and XML depending on accept-header.


Languages to be used
---------------------

 - C# - ASP.NET Core 8 MVC + Web API + MSTest (completed).
 - *Ruby - Ruby on Rails*
 - *Java (Play framework*
 - *Javascript (Node.js)*

Build and deploy (.NET)
-----------------------

    dotnet test dotnet/GANP.sln
    dotnet run --project dotnet/GANP.Website

GitHub Actions builds and tests every pull request (`ci.yml`) and deploys `master` to Azure App Service on Linux (`deploy.yml`) using OIDC federated login. Required repository secrets: `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_SUBSCRIPTION_ID`.
