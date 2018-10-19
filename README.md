# Project Title

Nordcloud assignment - a power grid calculation function, implemented as an Azure function.

### Prerequisites

[Visual studio](https://visualstudio.microsoft.com/vs/)
An active Azure subscription (you can get a [free account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F) if you don't have one).
The Azure functions tools for Visual Studio - see [this article](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs).

## Getting Started

Clone the repository, open the project in Visual studio, and run the NordCloudAssignment project.
You can call the API from postman: [![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/c2962df02e4c4ee2985f)

## Running the tests

Run all the tests in the NordCloudAssignmentTest project - the Tests are written with MSTest and should be recognized automatically by Visual Studio.

## Deployment

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmatthewdenobrega%2Fnordcloud-assignment%2Fmaster%2FNordCloudAssignment%2Fazuredeploy.json)
[![Visualize](http://armviz.io/visualizebutton.png)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fmatthewdenobrega%2Fnordcloud-assignment%2Fmaster%2FNordCloudAssignment%2Fazuredeploy.json)
After deploying, publish the function to the newly created PowerGridFunction function app.

## Built With

* [Azure functions](https://azure.microsoft.com/en-us/services/functions/) - Servless runner
* [Nuget](https://www.nuget.org/) - Dependency Management

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning.

## Authors

* **Matthew de Nobrega** - [MatthewDeNobrega](https://github.com/matthewdenobrega)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgements

[ARM template for function app on consumption plan](https://github.com/Azure/azure-quickstart-templates/tree/master/101-function-app-create-dynamic)