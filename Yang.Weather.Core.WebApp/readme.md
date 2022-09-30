To run the project, please do:
1.1. Add an appsetting.json file to the WebApp root path, with following settings plugged in with your own values:
 "ConnectionStrings": {
    "WeatherDbContext": ""
  },
  "GoogleMapApiKey": "",
  "OpenWeatherApiKey": "",
  "OpenWeatherApiUrl": "https://api.openweathermap.org/data/2.5/weather",
  "GoogleMapApiUrl": "https://maps.googleapis.com/maps/api/geocode/json"


  2. Create a SQL database "Openweather" in your localdb instance. If you don't have SQL Express installed already, [go download it](https://www.microsoft.com/en-us/Download/details.aspx?id=101064) and you must select the custom installation with localdb option.
  3. Run the CreateTables.sql script from (./Yang.Weather.Db/scripts) folder, which will create the tables needed for data storage in this exercise.