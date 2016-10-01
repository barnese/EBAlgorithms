# EBAlgorithms

Experimental playground for various algorithms and data structures written in .NET Core and C#.

## Contents

* **Generic Data structures**
  * AVLTree
  * BinarySearchTree 
    * breadth-first traversal
	* depth-first traversal (in-order, pre-order and post-order)
  * Graph
    * Search (breadth-first, depth-first)
	* Find shortest paths using Dijkstra and Bellman-Ford
	* Topological sort
  * HashMap
  * Heap (min-heap and max-heap)
  * LinkedList
  * PriorityQueue
  * Queue
  * Stack

* **Sorting** 
  * AVL sort
  * counting sort
  * heapsort
  * insertion sort
  * mergesort
  * quicksort
  * radix sort

* **Distance** 
  * Document distance using dot product of vectors
  * Levenshtein
  * Wagner-Fischer

* **Numbers** 
  * Catalan numbers
  * Heap's Algorithm for finding permutations of a list of integers
  * Lucas-Lehmer Mersenne prime number test
  * Sieve of Eratosthenes

* **Strings** 
  * Karp Rabin search
  * permutation finder
  * palindrome check

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
