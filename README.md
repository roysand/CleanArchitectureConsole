## Clean Architecture Console template
Change version of package in file nuget.csproj before pushing to GitHub.
Remember to create a branch before doing this.

## Dotnet commands
- dotnet pack .\nuget.csproj
- dotnet nuget push --source "MyGitHub" --api-key "acces-token" .\CleanArchitectureConsoleTemplate.1.0.x.nupkg --interactive
- dotnet new install CleanArchitectureConsoleTemplate::1.0.8 --interactive -d
