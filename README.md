# 🌦️ izolabella.OpenWeatherMap.NET
A library for communicating with the [OpenWeatherMap](https://openweathermap.org/) API.

Used mostly because I like to know when it rains and enjoy having the convenience of seeing the weather in places other than a dedicated app.

# 👩‍💻 Getting Started
This project is available through [NuGet.org](https://www.nuget.org/packages/izolabella.OpenWeatherMap.NET/);
- __Package Manager (Visual Studio)__
```
Install-Package izolabella.OpenWeatherMap.NET
```
- __.NET CLI__
```
dotnet add package izolabella.OpenWeatherMap.NET
```

# ⌨️ Code
A new instance of the `OpenWeatherMapClient` class must be initialized. This can be done while providing the `AppId` argument in the constructor immediately or the `AppId` can be set later, but if it isn't set before you attempt calling a method, the client will throw an `Exception`. This class also supports a specific unit type.
```cs
OpenWeatherMapClient Client = new("App Id", UnitTypes.Metric);
```

Various methods of communicating with the API are provided through processors used for different parts of the API.
```cs
. . .
WeatherResponse? Response = await Client.Processors.CurrentWeatherDataProcessor.GetWeatherByZipCodeAsync("00000", "US");
// WeatherResponse is a class containing generic, current weather information.
. . .

. . .
OneCallWeatherResponse? OneCallWeatherResponse = await Client.Processors.OneCallProcessor.CallAsync(0.0m, 0.0m);
// OneCallWeatherResponse is a class containing all possible relevant weather information regarding the given coordinates.
. . .
```

The `WeatherResponse` object might not always be null if an error has occurred (such as an invalid zipcode), check the `Cod` object for a 2xx http status code if necessary. Specific error types will more than likely be added later.
