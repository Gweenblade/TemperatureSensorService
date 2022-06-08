TemperatureSensorService is responsible for creating/patching/deleting/getting the temperature sensors.
Sensors get positions based on depth, circle of lattitude and meridian, the temperature is randomized during creating/patching the sensor.

For quick demo, you can use TemperatureSensorService.postman_collection, it contains all the requests needed to check the API, 
I also left swagger working on Azure intentionally.

Service is written in hexagonal architecture.

Once per hour service is sending reports about all of the temperature sensors to google drive.
You can check it here: https://drive.google.com/drive/folders/1kMzODBDotvTLaei_Ci01LltJAxetSDL3?usp=sharing

I implemented the token-based security. 
Basicly every generated token is a sensor token, which allows to get data about sensors. 
If user provied correct id and password, endpoint will create token with admin rights.

To handle the data I used SQLServer.