# Cocus Flights Manager
Cocus Expertise demonstration - Exercise 1

This application aims to provide the funcionalities identified in the first challenge:
 * CRUD of flights
 * Calculation of the distance and fuel consumption for a given aeroplane in a given flight
 
It was also provided the following functionalities:
 * CRUD of aeroplanes
 * CRUD of airports
 
The application consists in a RESTApi developed in .Net Core 2.2 and a frontend developed in React that consumes the services provided by the API.

The RESTApi was developed taking into consideration the Test Driven Development methodology, as well as a modular architecture, in which a class library was created in the solution in order to encapsulate the Database logic, the Business Services Logic and the Entity Models. In addition, the architecture takes special emphasys in Generalization through templated interfaces, Dependency injection, as well as MVVM patterns.

The presistance of the data was assured by an SQLExpress database, created by the Code-First methodology.
