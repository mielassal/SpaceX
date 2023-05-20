# SpaceXLaunches Project

The SpaceXLaunches project consists of a React application, a .NET 7 Minimal API, and an xUnit test project.

This project aims to provide a solution for managing SpaceX launches and conducting automated tests to ensure the reliability and functionality of the application.

The React app offers an interactive user interface, while the .NET 7 Minimal API serves as the backend for handling data and serving API endpoints.

The xUnit test project enables the execution of tests to validate the behavior and correctness of the application. With this project, users can explore SpaceX launches, interact with the API, and verify the expected functionality through automated testing.

## Getting Started

To get started with the project, follow the instructions below.

### Prerequisites

Make sure you have the following software installed on your machine:

- Node.js: [https://nodejs.org](https://nodejs.org)
- .NET SDK 7: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

### Navigate to SpaceX Project root directory

To access the SpaceX project, please follow these steps:

Open a terminal or command prompt.

Navigate to the root directory of the SpaceX project.

You can do this by either cloning the repository to your local machine using the command

```shell
git clone <repository-url>
```

or by downloading the compressed file and extracting it to your local machine.

or you download the project compressed file and uncompressed it to your local machine.

Once you have the project files on your local machine, use the command

```shell
cd SpaceX
```

### .NET 7 Minimal API Installation

Navigate to the dotnet-api directory

```shell
cd SpaceXLaunchAPI
```

Install the dependencies

```shell
dotnet restore
```

Run the .NET 7 Minimal API

```shell
dotnet run
```

To access the Swagger interface for the .NET 7 Minimal API, open your web browser and navigate to http://localhost:5026/swagger. If the browser displays the Swagger interface, it indicates that the API has been successfully installed and is ready for use.

### React App Installation

Navigate to the react-app directory:

```shell
cd spacex-launches-app
```

Install the dependencies

```shell
npm install
```

Start the React development server:

```shell
npm start
```

Open your browser and visit http://localhost:3000 to view the React app.

## Notes

Please note the following important information regarding the configuration of the React application and the Minimal API.

React Application:
If you need to modify the default URI configuration for running the React application, you can do so by updating the URI configuration in the .env file. Locate the .env file in the root directory of the React app, and modify the appropriate URI variables according to your desired configuration. This allows you to set the base URL and other related settings for the React app.

Minimal API Configuration:
To change the default URI configuration for the Minimal API, you can make adjustments in the appsettings.json configuration file. Inside the appsettings.json file, locate the AllowedOrigins section and update it with the desired origins and configurations. This configuration allows you to specify the origins that are allowed to access the Minimal API.

By following these configuration steps, you can customize the URI settings for both the React application and the Minimal API to suit your specific requirements.
