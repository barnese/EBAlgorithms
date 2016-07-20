# EBAlgorithms

Experimental playground for various algorithms and data structures written in .NET Core and C#.

## Project Layout

- **Source/EBAlgorithms** - class library containing the algorithms.
- **Source/Console** - console application for random tests during development.
- **UnitTests** - unit tests for the library.

## Building and Running

```Bash
cd Source\Console
dotnet run
```

Runs the console program.

```Bash
cd UnitTests
dotnet test
```

Runs the unit tests.

```Bash
dotnet build **/project.json
```

This builds all the projects from the root folder.
