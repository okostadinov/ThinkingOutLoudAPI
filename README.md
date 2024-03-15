### *WORK IN PROGRESS*

# Thinking Out Loud

### Description

TOL is my attempt at finally creating not merely a personal blog website, but a whole platform where users can write their own blogs and share them among each other.

It is possible that the frontend be created on a separate repo.

As it currently stands, only the base for the API layer has been created. I will be updating this README as I progress further with the features of the project.

### Usage
* clone the repo `git clone git@github.com:okostadinov/ThinkingOutLoudAPI.git`
* the project requires PostgreSQL to be installed for the respective OS of the machine: https://www.postgresql.org/download/
* it also requires the dotnet ef-tool: `dotnet tool install --global dotnet-ef`
* since it applies a code-first approach, you directly run the migrations: `dotnet ef database update` in order to generate the database
* to run the project `dotnet run`
* to build an executable `dotnet build`
