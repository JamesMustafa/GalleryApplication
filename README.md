# GalleryApplication

## Getting Started
GalleryApplication is a .NET Core 2.2 Web MVC project. It is based on the idea of collaboration of
all the worlds best artist in one place and creating an online gallery where you can see their arts, feel their lifestyle, go back
to the times they were living and most of all learn new things about the cultures in the past.

## Built With
* [.NET Core 2.2](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-2.2) - The web framework used

  * [Model-View-Controller (MVC) pattern](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-2.2)
  
  * [Identity on ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio) - Authentication system
  
    * Integrated [Google Sign-in](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1) into the web app
    
  * [Service Layer pattern](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs) - helps to reduce the conceptual overhead related to managing the service inventory
  
  * [SendGrid Email Sender](https://sendgrid.com) - Email Sender used for sending automatically generated emails.
  
  * [AutoMapper](https://automapper.org) - Auto Mapper for mappings
  
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli) - object-database mapper

  * [MySQL](https://www.mysql.com) RDBMS
  
  * [Repository pattern](https://deviq.com/repository-pattern/) - provides an abstraction of data
  
  * [Unit of Work pattern](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application) - intended to create an abstraction layer between the data access layer and the business logic layer of an application.
  
## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/JamesMustafa/GalleryApplication/blob/master/LICENSE) file for details

## Authors

* **Dzhem Mustafa**
