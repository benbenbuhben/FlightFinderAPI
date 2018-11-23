# Flight Finder API

**Author**: Ben Hurst

**Version**: 0.1.0

## Overview

## Getting Started

In a terminal instance:

1. ```git clone https://github.com/benbenbuhben/FlightFinderAPI.git```
2. ```cd FlightFinder API```

### Seed the SQLite Database from csv files

Note: This should already be done, but if .csv files are modified, place them in ```FlightFinderAPI/SampleData``` and run:

1. ```dotnet ef migrations add InitialCreate```
2. ```dotnet ef database update```

### Start the Server

1. ```dotnet run```

Client-side link and instructions to come!

## API Endpoints

## References

[ASP.NET Core Web API Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1)
[Working with SQL and .NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?tabs=aspnetcore2x&view=aspnetcore-2.1)

## Change Log

11-20-2018 11:00am - Completed Initial Scaffolding based on ASP.NET Web API Tutorial

11-20-2018 1:24pm - SQLite database successfully seeding with sample .csv data.

11-20-2018 2:22pm - Proof of life for /api/flights endpoints.
