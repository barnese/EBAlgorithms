# EBAlgorithms

Experimental playground for various algorithms and data structures written in .NET Core and C#.

## Contents

- **Generic Data structures** - AVLTree, BinarySearchTree, Graph, HashMap, Heap, LinkedList, PriorityQueue, Queue, Stack
- **Sorting** - including mergesort, quicksort, heapsort, and others
- **Distance** - Document distance using dot product of vectors, Levenshtein, Wagner-Fischer
- **Numbers** - Catalan numbers, Lucas-Lehmer Mersenne prime number test
- **Strings** - Karp Rabin search, permutation finder, palindrome check

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
