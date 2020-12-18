# Backend technical test for First AML

This repository contains code for the First AML back end technical test. The goal is to provide
a library which calculates the cost of shipping an order of parcels.

## Examples

TBD

## Building

In order to compile the library and run the unit tests you can execute the `build.ps1` powershell
script. This script will

* Determine the version using [GitVersion](https://github.com/GitTools/GitVersion)
* Update the project file versions
* Compile the projects and create a NuGet package in the `bld\deploy` folder of the workspace
* Execute the unit tests