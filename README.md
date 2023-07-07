# dotnet-web-app
An end-to-end E-commerce Web Application

## Table of Contents
- [dotnet-web-app](#dotnet-web-app)
  - [Table of Contents](#table-of-contents)
  - [General Information](#general-information)
  - [Technologies, Frameworks, and Tools](#technologies-frameworks-and-tools)
  - [Setup](#setup)
  - [Endpoints](#endpoints)
    - [Movies](#movies)
    - [Actors](#actors)
    - [Producers](#producers)
    - [Cinemas](#cinemas)
  - [To-Dos](#to-dos)
  - [Acknowledgements](#acknowledgements)


## General Information
A simple MVC Web Application using [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-7.0&tabs=windows) and its related frameworks.


## Technologies, Frameworks, and Tools
- [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [LINQ](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/linq-to-entities)
- [MS SQL Server](https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16)
- [Windows Subsystem for Linux (Ubuntu 20.04.6)](https://ubuntu.com/tutorials/install-ubuntu-on-wsl2-on-windows-10#1-overview)
- [Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet)
- [RestSharp](https://restsharp.dev/intro.html#introduction)

## Setup

- Here is a [Quick Introduction](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/) to Wep Application with .NET CORE
  - Install [.NET CORE](https://dotnet.microsoft.com/en-us/download)
  - Install [Visual Studio](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022) OR [Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet)
  - Install [MS SQL Server](https://learn.microsoft.com/vi-vn/ef/core/providers/sql-server/?tabs=dotnet-core-cli)


## Endpoints
- The landing page can be access through: `http://localhost:5045/`
- Admin Account (Create, Update, Delete): 
  - Gmail: `admin@gmail.com`
  - Password: `Coding@1234?`

### Movies
  - `/Movies` - List all movies 
  - `/Movies/Details/{Id}` - See all information of a movie
  - `/Movies/Edit/{Id}` - Modify the detail of a movie
  - `/Movies/Create` - Add a new movie to the database

### Actors
  - `/Actors` - List all actors
  - `/Actors/Details/{Id}` - See all information of an actor
  - `/Actors/Edit/{Id}` - Modify the detail of an actor
  - `/Actors/Delete/{Id}` - Delete an actor from the database
  - `/Actors/Create` - Add a new actor to the database

### Producers
  - `/Producers` - List all producers
  - `/Producers/Details/{Id}` - See all information of an actor
  - `/Producers/Edit/{Id}` - Modify the detail of a producer
  - `/Producers/Delete/{Id}` - Delete a producer from the database
  - `/Producers/Create` - Add a new producer to the database

### Cinemas
  - `/Cinemas` - List all cinema
  - `/Cinemas/Details/{Id}` - See all information of a cinema
  - `/Cinemas/Edit/{Id}` - Modify the detail of a cinema
  - `/Cinemas/Delete/{Id}` - Delete a cinema from the database
  - `/Cinemas/Create` - Add a new cinema to the database


## To-Dos
- [x] Models
- [x] Views
- [x] Controllers
- [x] SQLite Migration
- [x] CRUD Operations
- [x] Services
- [x] Migrate to MS SQL Server
- [x] Authentication/Authorization
- [ ] Integrate [MoviesDatabase API](https://rapidapi.com/SAdrian/api/moviesdatabase)



## Acknowledgements
- This project was based on [this tutorial](https://www.youtube.com/watch?v=Jp25zkAGHJc&list=PL2Q8rFbm-4ruTcZY39MNOsEu4p76HQ5VX&index=26).
