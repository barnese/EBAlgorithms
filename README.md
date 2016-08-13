# EBAlgorithms

Experimental playground for various algorithms and data structures written in .NET Core and C#.

## Contents

- **Data structures** - Linked list, queue, binary search tree, AVL tree, hash map.
- **Sorting algorithms** - including mergesort, quicksort, heapsort, etc.
- **Numbers** - Catalan numbers, Lucas-Lehmer Mersenne prime number test.
- **Strings** - Karp Rabin search
- **Other** - Document distance finder

## Project Layout

- **Source/EBAlgorithms** - class library containing the algorithms.
- **Source/Console** - console application for random tests during development.
- **UnitTests** - unit tests for the library.

## Building and Running

To run the console program:

```Bash
cd Source\Console
dotnet run
```

To run the unit tests:

```Bash
cd UnitTests
dotnet test
```

To build all the projects from the root folder:

```Bash
dotnet build **/project.json
```
