# Readme 


## Solution structure

- Creating using the CLI
```sh
# Trust dotnet development certificates
dotnet dev-certs https --trust

# Select a dotnet sdk
dotnet new globaljson --sdk-version 2.2.301

# Create edge apis and tests
dotnet new webapi --no-https --no-restore --name Demo.Edge.xxxxx
dotnet new xunit --no-restore             --name Demo.Edge.xxxxx.Tests

# Create microservice apis and tests
dotnet new webapi --no-https --no-restore --name Demo.Edge.xxxxx
dotnet new xunit --no-restore             --name Demo.Edge.xxxxx.Tests

# Create system tests
dotnet new xunit --no-restore             --name Demo.Tests

# Create react apps
yarn create react-app demo-web-xxxxx --typescript

# Create solution
dotnet new sln --name Demo

# Add projects to solution
dotnet sln add Demo.*
```