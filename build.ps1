Push-Location $PSScriptRoot

& dotnet restore --no-cache
& dotnet build -c Release

& dotnet test test/ArgsMapper.Test/ArgsMapper.Test.csproj -c Debug `
    /p:CollectCoverage=true `
    /p:CoverletOutputFormat=opencover `
    /p:CoverletOutput=../../artifacts/coverage.xml `
    /p:Exclude=[xunit*]*

if ($env:APPVEYOR_JOB_ID) {
	& dotnet tool install coveralls.net --version 1.0.0 --tool-path tools

	$coveralls = ".\tools\csmacnz.coveralls"

	& $coveralls --opencover -i .\artifacts\coverage.xml `
		--repoToken $env:COVERALLS_API_TOKEN `
		--commitId $env:APPVEYOR_REPO_COMMIT `
		--commitBranch $env:APPVEYOR_REPO_BRANCH `
		--commitAuthor $env:APPVEYOR_REPO_COMMIT_AUTHOR `
		--commitMessage $env:APPVEYOR_REPO_COMMIT_MESSAGE `
		--jobId $env:APPVEYOR_JOB_ID
}