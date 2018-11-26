<a id="top"></a>
# Flight Finder API

**Author**: Ben Hurst

**Version**: 0.1.0

**Live Site**: http://imaginary-air.s3-website-us-west-2.amazonaws.com/

**Live Server ***(redirects to Swagger API Docs)*****: https://flightfinderapi.azurewebsites.net/

**Front-end GitHub Repo:** https://github.com/benbenbuhben/flight-finder-client
___

## Table of contents
* [Overview](#overview)
* [Getting Started](#gettingStarted)
  * [Clone Repo](#clone)
  * [Seed Database](#seed)
  * [Run Tests](#test)
  * [Start Server](#run)
* [API Endpoints](#endpoints)
* [Models](#models)
  * [Airport Model](#airport-model)
  * [Flight Model](#flight-model)
* [References](#references)
* [Change Log](#change-log)

___

<a id="overview"></a>
## Overview

Simple ASP.NET Core API to serve airport flight information. Data is loaded from CSV files (using the NuGet package [CSVHelper](https://joshclose.github.io/CsvHelper/)) into a SQLite database upon startup and then dynamically accessed through HTTP requests.

___

<a id="gettingStarted"></a>
## Getting Started in Development (using .NET Core CLI tool)

<a id="clone"></a>

### Clone this repo

In a terminal instance:

1. ```git clone https://github.com/benbenbuhben/FlightFinderAPI.git```
2. ```cd FlightFinderAPI/```

<a id="seed"></a>

### Seed the SQLite Database from csv files

*Note*: This should already be done, but if .csv files are modified, place them in ```FlightFinderAPI/wwwroot/SampleData``` and run:

1. Navigate to second-level ```FlightFinderAPI``` directory.
2. ```dotnet ef migrations add InitialCreate```
3. ```dotnet ef database update```

<a id="test"></a>

### Run Tests

1. Navigate to ```FlightFinderTests``` directory.
2. ```dotnet test```

<a id="run"></a>

### Start the Server

1. Navigate to second-level ```FlightFinderAPI``` directory.
2. ```dotnet run```

___
<a id="endpoints"></a>
## API Endpoints

*Note:* Existing endpoints created to satisfy front-end requirements. Further CRUD endpoints could easily be incorporated if necessary.

**GET** `/api/airports/all`

***Client-side Usage:*** Called on page load (during ```componentWillMount()``` on SearchForm component) to dynamically seed valid form input with current airport options. Response includes names and codes corresponding to all unique airports in JSON format.

***Example Response:***

    [
        {
            "id": 1,
            "code": "SEA",
            "name": "Seattle WA (SEA-Seattle/Tacoma Intl.)"
        },
        {
            "id": 2,
            "code": "LAS",
            "name": "Las Vegas NV (LAS-McCarran Intl.)"
        },
        {
            "id": 3,
            "code": "LAX",
            "name": "Los Angeles CA (LAX-Los Angeles Intl.)"
        },
        {
            "id": 4,
            "code": "PHX",
            "name": "Phoenix AZ (PHX-Sky Harbor Intl.)"
        }
    ]

___

**GET** `/api/flights/search?from={origin}&to={destination}`

***Client-side Usage:*** Called from "Find Flights" button submit. Response includes all columns from corresponding origin and destination airports in JSON format. Query parameters take form of respective airport codes and are required.

***Example Response:***

`/api/flights/search?from=SEA&to=PHX`

    [
        {
            "id": 33,
            "from": "SEA",
            "to": "PHX",
            "flightNumber": 1000,
            "departs": "2018-11-23T18:00:00",
            "arrives": "2018-11-23T20:00:00",
            "mainCabinPrice": 100,
            "firstClassPrice": 200
        },
        {
            "id": 34,
            "from": "SEA",
            "to": "PHX",
            "flightNumber": 1001,
            "departs": "2018-11-23T19:00:00",
            "arrives": "2018-11-23T21:00:00",
            "mainCabinPrice": 110,
            "firstClassPrice": 190
        },
        {
            "id": 35,
            "from": "SEA",
            "to": "PHX",
            "flightNumber": 1002,
            "departs": "2018-11-23T16:00:00",
            "arrives": "2018-11-23T18:00:00",
            "mainCabinPrice": 99,
            "firstClassPrice": 175
        },
        {
            "id": 36,
            "from": "SEA",
            "to": "PHX",
            "flightNumber": 1003,
            "departs": "2018-11-23T07:00:00",
            "arrives": "2018-11-23T09:00:00",
            "mainCabinPrice": 132,
            "firstClassPrice": 214
        }
    ]
___
<a id="models"></a>
## Models

<a id="airport-model"></a>

### 1. Airport Model
    Airport{
      id	integer($int32)
      code	string
      name	string
    }
    
<a id="flight-model"></a>

### 2. Flight Model
    Flight{
      id                integer($int32)
      from              string
      to                string
      flightNumber      integer($int32)
      departs           string($date-time)
      arrives           string($date-time)
      mainCabinPrice    integer($int32)
      firstClassPrice   integer($int32)
    }

<a id="references"></a> 
## References

[ASP.NET Core Web API Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1)

[Working with SQL and .NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?tabs=aspnetcore2x&view=aspnetcore-2.1)

<a id="change-log"></a> 
## Change Log

11-20-2018 11:00am - Completed Initial Scaffolding based on ASP.NET Web API Tutorial

11-20-2018 1:24pm - SQLite database successfully seeding with sample .csv data.

11-20-2018 2:22pm - Proof of life for /api/flights endpoints.

11-23-2018 5:17pm - Added test framework.

11-24-2018 7:38pm - Deployed to Azure.

[Back to top](#top)
