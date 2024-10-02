# **DLS Compulsory** :monocle_face:

## Introduction

In our system, we are primarily focused on the logging aspect. If we align this with the 'Design to be monitored' framework, our focus would be more on the middle level of the image. This is because we are prioritizing the identification of 'where' the problems are occurring, and logging data is essential for this task.

## **C4 Model** :pencil2:

This document provides a comprehensive C4 model breakdown of a monitoring system, detailing its architecture down to the third level. It outlines a blueprint for implementing and integrating such a system into any system requiring monitoring capabilities

![FullC4Model](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/C4Model.png)

Her a link to our [project](https://www.figma.com/board/892iLuWnOICp8H1fiWFxyl/DLS-Compulsory?node-id=38-425&node-type=section&t=nANISoYMvT7RMDkZ-0) in Figma for a closer look

### **Level 1** :bricks:

This image is a context diagram that illustrates the relationship between a monitoring user, a monitoring system, and any other system that might be monitored.

![LVL1](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/Level%201%20Monetoring%20System%20context%20diagram.png)

### **Level 2** :hammer:

The diagram shows the relationships between these components and the data flow between them. For example, the monitoring user interacts with the monitoring web app, which in turn queries the monitoring database to retrieve monitoring data. The logging and tracing APIs collect data from the monitored systems and store it in the database.

![LVL2](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/Level%202%20Container%20diagram%20Monetoring%20System.png)

### **Level 3** :wrench:

#### Logging Api :goal_net:

The Logging API receives data from "Any System",it is than using the Logging Service Component, and stores it in the Logging Database. The Logging Distributor then distributes the logging data to other components in the monitoring system.Logging Distributor is to ensure that the logging data is delivered to the appropriate components where it can be used for analysis, monitoring, or other purposes.

![LVL3Logging](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Logging%20API.png)

#### Tracing Api

The Tracing API gathers information from the system being monitored. This data is then analyzed and processed by a specialized component. The processed information is stored in a database for later reference. Finally, this data is shared with other parts of the monitoring system.

![LVL3Tracing](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Tracing%20API.png)

#### Monitoring WebApp

The Monitoring WebApp as a bridge between the user and the monitored system. The Monitoring View is the user interface that displays relevant data. The Monitoring Controller acts as the middleman, receiving user input and sending it to the backend (the Monitoring API) to fetch and update data. The Monitoring Model represents the data structure used to store and manipulate the information displayed in the view.

![LVL3WebApp](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Monitoring%20WebApp.png)

#### Monitoring Api

The Monitoring View shows users the data they need. The Monitoring Controller acts as the gatekeeper, receiving user requests and deciding what to do. The Monitoring Service Component is the worker behind the scenes, fetching data from or sending updates to the database. The Monitoring Database stores all the information about the system being monitored.

![LVL3Monitoring](https://github.com/Rogengell/DLS-Compulsory-Logging-Api/blob/main/Diagrams/Level%203%20Components%20diagram%20-%20Monitoring%20API.png)

## **Coding decisions**

### **Entity Framework**

Entity Framework is used for the communication to the Database and back. It is even used for setup of the Database and the migration in our DB

### **RestAPI:**

By using a rest API, we will be able to create a more modular, scalable and flexible Monitoring System that is easier to maintain and extend

### **Dependency Injection:**

Dependency injection helps organize our code by specifying which services can access other services they need to do their jobs. This makes our code more flexible, maintainable, and easier to test.

### **Nginx:**

We are using Nginx, because it is a valuable tool for horizontal scaling in Docker environments, it helps us so we are able to use the api's container outside docker. It's like a gateway to the api's

## **Setup Logging API** :rocket:

:rotating_light: Before running docker compose up please check if in the file **run-ef-database-update.sh** the **Line Sequence** is set to **LF** and not to **CRLF**. :rotating_light:

After that you can run this command

```
docker compose up
```

When it is finish after round about 1 min, than you can tryout via swagger and input some loggings to the database.
Todo so open your preferred browser and type **localhost/swagger**

This is an example the json body how it would look before sending

```
{
  "traceId": 2147483647,
  "parentSpanId": 2147483647,
  "loggingString": "string",
  "time": "2024-10-02T08:40:28.161Z"
}
```

- **traceId:** This value cant be null, it represents the trace and it is the connection between the logging and tracing.
- **parentSpanId:** This value can be null, it combines Spans together if they are in the same logging process.
- **loggingString:** This value can be null, it is the info message that will be stored in the database.
- **time:** This value can be null, it represents the time of the user machine or of the server.
