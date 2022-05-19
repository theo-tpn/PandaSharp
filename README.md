# PandaSharp

## Overview
 PandaSharp is a lightweight .NET SDK for PandaScore APIs.
 
https://www.nuget.org/packages/PandaSharp/

## Getting Started

In Program.cs
```csharp
//add PandaSharp client to service collection
builder.Services.AddPandaSharp(builder.Configuration);
```

Get your API Key on : [PandaScore Dashboard](https://app.pandascore.co/dashboard/main)

Configuration in appsettings.json
```json
"ConnectionStrings": {
    "PandaScore": {
      "ApiUrl": "https://api.pandascore.co/",
      "ApiKey": "YOUR_API_KEY"
    }
  }
```

## PandaRequest
PandaRequest give access to methods in order to build PandaScore calls.

Request below will return list of matches for league with the given 'leagueId'
 ```csharp
var request = new PandaRequest().From(PandaEntity.Leagues).By(leagueId).Get(PandaEntity.Matches);
 ```
### PandaQuery
 PandaQuery can be chain to PandaRequest in order to sort, filter, range and search over PandaScore endpoints.

 The query below will ask for players where name contains 'pew' and sort them ascending based on their name too.
 ```csharp
 var request = new PandaRequest()
    .Get(PandaEntity.Players)
    .AddQuery(
        new PandaQuery()
        .AddSort<Player>(
            new Dictionary<Expression<Func<Player, object>>,  PandaScoreSortOption>
            {
                { x => x.Name, PandaScoreSortOption.Ascending }
            })
        .AddSearch<Player>(x => x.Name, "pew"););

 ```
## Execute call

```csharp
//using PandaRequest and PandaQuery object
var result = await client.Execute<List<Match>>(myPandaRequest);
var result = await client.Execute<List<Match>>(myPandaRequest, myPandaQuery);

//using own string request and query
var result = await client.Execute<List<Match>>("string_request");
var result = await client.Execute<List<Match>>("string_request", "string_query");
```

## Read the docs
Some builds of PandaRequest or PandaQuery does not return anything.
Please read [PandaScore API Reference](https://developers.pandascore.co/reference/) to know what calls can be made. 
