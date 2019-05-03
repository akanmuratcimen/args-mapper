Push-Location $PSScriptRoot

& dotnet restore --no-cache
& dotnet build -c Release
& dotnet test
