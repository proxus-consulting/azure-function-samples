# Tips & Tricks on usefull features working with Azure Functions!
## Dependency Injection

From the docs: https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
This guide is good, but it can be improved :) 

Steps needed:
1. Install Nugets
2. Register Services
3. Use Services

### Install Nugets:
```Install-Package Microsoft.Azure.Functions.Extensions -Version 1.1.0```

```Install-Package Microsoft.Extensions.DependencyInjection -Version 3.1.11``` 
**As for January 2021, only .net 3.* is supported when deploying to Azure, therefore the package downgrade**
