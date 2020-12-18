<#
    .SYNOPSIS

    Compiles the solution file in the source folder and executes the unit tests for that solution
#>
[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'

# ------------------ Functions ----------------------

function Get-Version
{
    $tempDir = Join-Path (Join-Path $PSScriptRoot 'bld') 'temp'
    $gitVersion = Join-Path (Join-Path (Join-Path $tempDir 'GitVersion.CommandLine') 'tools') 'gitversion.exe'
    if (-not (Test-Path $gitVersion))
    {
        if (-not (Test-Path $tempDir))
        {
            New-Item -Path $tempDir -ItemType Directory | Out-Null
        }

        $nuget = Join-Path $tempDir 'nuget.exe'
        if (-not (Test-Path $nuget))
        {
            Invoke-WebRequest -Uri 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' -OutFile $nuget
        }

        & nuget install GitVersion.CommandLine -ExcludeVersion -OutputDirectory $tempDir -NonInteractive -Source https://api.nuget.org/v3/index.json
    }

    $output = & $gitVersion $PSScriptRoot /updateprojectfiles /l (Join-Path $tempDir 'gitversion.log')
    $jsonOutput = ConvertFrom-Json -InputObject ($output | Out-String)
    return $jsonOutput.FullSemVer
}

# ------------------ End Functions ------------------

# Update the versions of the assemblies
$version = Get-Version

Write-Output "Using version: '$version'"
Write-Output ''

dotnet build .\src\FirstAML.Couriers.sln --no-incremental --nologo

dotnet test .\src\FirstAML.Couriers.sln