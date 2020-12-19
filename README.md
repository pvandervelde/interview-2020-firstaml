# Backend technical test for First AML

This repository contains code for the First AML back end technical test. The goal is to provide
a library which calculates the cost of shipping an order of parcels.

## Examples

For some examples on how to use the code please see the `OrderIntegrationTest`.

## Building

In order to compile the library and run the unit tests you can execute the `build.ps1` powershell
script. This script will

* Determine the version using [GitVersion](https://github.com/GitTools/GitVersion)
* Update the project file versions
* Compile the projects and create a NuGet package in the `bld\deploy` folder of the workspace
* Execute the unit tests

## Future improvements

* At the moment the library uses the `decimal` type to handle monetary values. This means that there
  is no currency information, only information about the value. If parcels need to be shipped
  internationally then currencies will become important.
* At the moment there is no diagnostic information available about how an order came together. This
  may or may not be useful in the future.
