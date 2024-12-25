# Online school  system 

A simple website created with **ASP. Net Core 7**, **C#** and **MS SQL Server** allow members to download  courses online.


### Technologies

* ASP.NET Core 7
* C#
* MS SQL Server 2022, Entity Framework Core
* Web API

  
## Project Structure
https://github.com/naghmehjalal/School_CleanArchitect/blob/main/Project%20Structure.png

 ### Api 
 
 ## Swagger (Swashbuckle)

 1. Install NuGet Package 
  **Swashbuckle.AspNetCore 6.5.0**
  

## JWT Bearer     
1. Install NuGet Package 
	**Microsoft.AspNetCore.Authentication.JwtBearer**

2. Add Configuration into ```appsetting.json```
- JwtSettings : Key
- JwtSettings: Issuer
- JwtSettings: Audience
- JwtSettings: DurationInMinutes
    

>> Connection string defined in ```Web.API/appsettings.json```




1. Install NuGet Package
   
	Infrastructure.Identity
	**MediatR**
	**MediatR.Extensions.Microsoft.DependencyInjection**
        **AutoMapper.Extensions.Microsoft.DependencyInjection**
        **Microsoft.AspNetCore.Identity**
        **FluentValidation.DependencyInjectionExtensions**
        **Microsoft.AspNetCore.Authentication.JwtBearer**
        **Newtonsoft.Json**
        **System.IdentityModel.Tokens.Jwt**
   
	Core.Application
	**MediatR**
	**MediatR.Extensions.Microsoft.DependencyInjection**
        **AutoMapper.Extensions.Microsoft.DependencyInjection**
        **Microsoft.AspNetCore.Identity**
        **FluentValidation.DependencyInjectionExtensions**
	**Microsoft.AspNetCore.Identity**
	**Microsoft.AspNetCore.Identity.EntityFrameworkCore**

	Web.api
	  **Swashbuckle.AspNetCore 6.5.0**
	  **NSwag.AspNetCore 14.2.0**
	  **MediatR 12.0.1**
	  **Microsoft.AspNetCore.Authentication.JwtBearer**
	  **Microsoft.IdentityModel.Tokens**
	  **Microsoft.EntityFrameworkCore.SqlServer**
	  **Microsoft.EntityFrameworkCore.Tools**

2. Update   class  UserConfiguration in  (Infrastructure.Identity/Configurations/UserConfiguration)
    UserName , PasswordHash , Email
   
3.  Update  Group and Subgroup
  > ```AppContext.cs.``` in Infrastructure.Persistence
  > region  ```Seed Course```
  

4. Create Migrations
	```Add-Migration -Name "AppContext"
 
5. Run the Migrations```
	```Update-Database```

6. Create Migrations
	```Add-Migration -Name "IdentityDbContext" 

7. Run the Migrations
	```Update-Database```
