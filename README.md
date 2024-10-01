# **DLS Compulsory** :monocle_face:

## Introduction
In our system, we are primarily focused on the logging aspect. If we align this with the 'Design to be monitored' framework, our focus would be more on the middle level of the image. This is because we are prioritizing the identification of 'where' the problems are occurring, and logging data is essential for this task.

## **C4 Model** :pencil2:
This document provides a comprehensive C4 model breakdown of a monitoring system, detailing its architecture down to the third level. It outlines a blueprint for implementing and integrating such a system into any system requiring monitoring capabilities

![FullC4Model](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/C4Model.png)

Her a link to our [project](https://www.figma.com/board/892iLuWnOICp8H1fiWFxyl/DLS-Compulsory?node-id=38-425&node-type=section&t=nANISoYMvT7RMDkZ-0) in Figma for a closer look

### **Level 1** :bricks:
This image is a context diagram that illustrates the relationship between a monitoring user, a monitoring system, and any other system that might be monitored.
wrong image!!!!!!!!!!!
![LVL1](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/Level%201%20Monetoring%20System%20context%20diagram.png)

### **Level 2** :hammer:

![LVL2](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/Level%202%20Container%20diagram%20Monetoring%20System.png)

### **Level 3** :wrench:

#### Logging Api :goal_net:

![LVL3Logging](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Logging%20API.png)

#### Tracing Api

![LVL3Tracing](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Tracing%20API.png)

#### Monitoring WebApp

![LVL3WebApp](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Monitoring%20WebApp.png)

#### Monitoring Api

![LVL3Monitoring](https://github.com/Rogengell/DLS-Compulsory-Health-App-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Monitoring%20API.png)

## **Code**

- restAPI
- dependency injection
- We are using Nginx, because it is a valuable tool for horizontal scaling in Docker environments, providing load balancing, performance optimization, and fault tolerance.

## **Setup Monitoring Programm** :rocket:

make sure that all .NET Core frameworks are up to date, for at get a list of all tools, run this command

```
dotnet tool list -g
```

for running migration pls run this command

```
dotnet tool install --global dotnet-ef
```

```
docker compose up
```

after that you can tryout via swagger and input some loggings to the database
open your browser and type

```
localhost/swagger
```
