### In a nutshell

Allows to provide an instance to a client that has a dependency on an interface that your instance does not implement.

### Class Adapter

Through inheritance you extend the class needed to implement the new functionality. Whitebox reuse because depends on implementation of the class, rather than an interface.

### Object Adapter

Uses composition to delegate from the methods of a desired interface to those of a contained, encapsulated object in the Adapter. The object may be passes through the constructor of the Adapter. Blackbox reuse because you don't need to see the implementation and thus limiting the dependency to the interface being adapted, making it possible for the implementation to vary.

https://refactoring.guru/design-patterns/adapter/csharp/example

Reference:
(1) McLean, H. G. (2017). *Adaptive Code: Agile coding with design patterns and SOLID principles, 2nd Edition*. Microsoft Press

