# ASP.NET Core WebAPI  -RESTful Webservices mit C#
---
KursRepository zu Kurs ASP.NET Core Web API - RESTful Webservices mit C# der ppedv AG

## Modul 001 Einf�hrung WebAPI

	-	[x] WheaterForecastAPI erstellt
	-	[x] Projektstruktur erkl�rt
	-	[x] [httpFiles](https://learn.microsoft.com/en-us/aspnet/core/test/http-files)

## Modul 002 Konfiguration

	-	[ ] IOC mittels Dependency Injection
	-	[ ] Logging in ASP.Net Core

## Modul 003 Controllers

	-	[ ] BusinessLogic Class Library Project erstellt
	-	[ ] Vehicle Demo Klassen
	-	[ ] Interface als Contract extrahiert

## Modul 004 Routing, MediaTypes, Async/Await

	-	[ ] Controller mit CRUD Operationen

	-	[ ] Route constraints
	-	[ ] [Model Binding](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/)

	-	[ ] Content Negotiation
	-	[ ] MediaTypes & [Formatters](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/media-formatters)
	-	[ ] ActionResults als XML zur�ck geben 
	-	[ ] ActionResults als CSV zur�ck geben 

	-	[ ] Async/Await Pattern
	-	[ ] LAB: Movie Store Api

## Modul 005 EF Core

	-	[ ] Code First: VehicleFleet Datenbank
	-	[ ] Datenklasse mit Attriuten versetzt
	-	[ ] DbContext erzeugt
	-	[ ] Connection string erstellt
	-	[ ] Abh�ngigkeiten via DI registriert
	-	[ ] Best Practices: DTOs, Mapper
	-	[ ] Validierung in DTOs
	-	[ ] LAB: DB f�r Movie Store erstellen

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add myInitialScript --project myProject
dotnet ef database update --project myProject
```

	-	[ ] Db First: Northwind Datenbank
	-   [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
	-	[ ] VS Extension [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
	-	[ ] Controller erzeugen
	-	[ ] LAB: Daten von Northwind abfragen
			* Alle Bestellungen
			* Alle Bestellungen innerhalb eines Zeitraumes (Parameter: StartDate, EndDate)
			* Bestellungen pro Kunde (Parameter: CustomerID)
			* Kunden pro Land (Parameter: Country)

## Modul 006 Testing

	-	[ ] [�berblick Strategien](https://learn.microsoft.com/de-de/ef/core/testing/)
	-	[ ] [Unit Testing Controllers](https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api)
	-	[ ] Moq benutzen um Controller Dependencies zu mocken
	-	[ ] LocalDB benutzen

## Modul 007 HttpClient

	-	[ ] Console App welche Anfragen auf die Northwind API macht
	-	[ ] Response als JSON deserialisieren

## Modul 008 Authentication

	-	[ ] Middleware f�r Authentication konfigurieren
	-	[ ] IdentityDbContext verwenden
	-	[ ] JwtToken erstellen

	-	[ ] Authentication mit Microsoft Identity Platform via Entra (ehem. Azure AD)
	-	[ ] [Client Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
	-	[ ] [Graph Explorer](https://developer.microsoft.com/en-us/graph/graph-explorer)

	
## Modul 009 OData

	-	[ ] OData Abfragen auf Northwind
