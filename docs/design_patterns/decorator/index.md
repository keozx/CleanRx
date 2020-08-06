---
layout: single
sidebar:
  nav: "docs"
---

## In a nutshell

Similar to adapter, but decorator takes dependency of the decorator object instead of inheritance, but must implement the interface, and thus can extend (decorate) it's functionality.

[](https://www.dotnettricks.com/learn/designpatterns/decorator-design-pattern-dotnet)

## Composite pattern specialization

- Allows you to treat many instances of an interface as if they were just one instance, manages an internal collection of instances to enable this. You can chain them as they implement the same interface being decorated.

[](https://dofactory.com/net/composite-design-pattern)

## Predicate decorators

- You pass predicate logic to be executed before the actual behavior is executed, usually through another dependency that provides the predicate tester. Resembles the Adapter pattern.

- You can use as branching decorator when executing logic of an decorator component over another based on some predicate logic. Similar to Strategy pattern.

## Lazy decorator

- When the decorator implements the interface, a client can be unaware of the dependency of a Lazy\<T>. Instead of having to pass the Lazy object, the interface allows to use the component through the interface

```
LazyComponent : IComponent
{
    public LazyComponent(Lazy<IComponent>){}
}

public ComponentClient(IComponent component) // instead of Lazy<T>
```

## Profiling + Logging decorator

- Interesting use of polymorphism of interfaces to make use of profiled decorated implementations.

## Advantages

- Functionality can be added to an existing class that implements a certain interface, and the decorator also acts as an implementation of the interface

Reference:
(1) McLean, H. G. (2017). *Adaptive Code: Agile coding with design patterns and SOLID principles, 2nd Edition*. Microsoft Press