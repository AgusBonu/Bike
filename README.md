# Bike
Structure of development
DAL -> BAL -> APP ASP.Net MVC
DAL <- BAL <- APP ASP.Net MVC

For this project a layered development was used. Physically sharing the code of the db, the logic, and the user's view


DAL ( data acces logic ) 
This contains the mapping of the database created with entity framework

BAL ( bussines acces logic )

This contains copies of the DAL entity and functions as an intermediary passing objects and allowing data to be transmitted from the BD to the APP and from the APP to the BD.

APP ASP.NET MVC

For the user's view, a project was created in ASP.NET MVC

If a development on multiple devices is necessary, it would only be necessary to create a WEB MVC API that functions as an intermediary between the BAL and the user's view. As detailed below.


DAL -> BAL -> API ASP.NET MVC  

APP Android, App ASP.NET MVC, APP Angular , (etc.) connect to API ASP.NET MVC

The Axo Cover plugin was used for the unit tests since the comunnity version of visual studio was used.



