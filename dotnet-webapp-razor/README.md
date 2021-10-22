
# Example application using Lob APIs

This is a sample application to show how easy it is to get started using C#. Use your own Lob API key by adding it to the `docker-compose.yml` file. 
This sample app makes use of the [Address Book API](https://docs.lob.com/#tag/Addresses) and the [Address Verification API](https://docs.lob.com/#operation/us_verification).

## Connecting to the API

The main action is happening in the `LobExampleApp/LobConnector.cs`. This example is using [Flurl](https://flurl.dev/), but you can drop in any replacement that you like. Authenticating to the Lob API is very simple, just put your Lob API in the username property with an empty password in [Basic Auth](https://docs.lob.com/#tag/Authentication).

## How to start this application

Clone the Github repo and change directories to `dotnet-webapp-razor`. You must have Docker installed on your local machine. 

1. Place your Lob API key in the `LobExampleApp/Properties/launchSettings.json` file. 
2. From the root of the `dotnet-webapp-razor` folder run `docker-compose up`. 
3. You are able to see the application on "http://localhost:5001"


