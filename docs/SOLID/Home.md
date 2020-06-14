# S 
## Single responsability principle

One responsability and one reason to change.

# O
## Open/Closed principle

Maintain loosely coupled classes so that code changes during bug fixing cycle does not affect client code.

When there are no extension points, clients are forced to change.
- Virtual/abstract methods, but composition preferred over inheritance implementation
- Interface inheritance, avoids client-aware changes or reduces them as no implementation dependency is defined.

Balance extension with *predicted variation*, apply where requirements unclear, changeable or difficult to implement. Predicted lack of variation avoids *speculative generality* where there is no domain variability and rigidly defined across layers of dependency.

# L
Liskov Substitution principle

### Contract rules
- *Preconditions* cannot be strenthened in a subtype.
    - Guard clauses
    - Consider new types if many conditions (encapsulation)
- *Postconditions* cannot be weakened in a subtype.
    - These ensure object valid state after computations
- *Invariants* of the supertype -conditions that must remain true- must be preserved in a subtype.
    - Predicates that remain true for the lifetime of an object

### Variance rules

- There must be *contravariance* of the method arguments in the subtype.
    - *against* : inverts the hierarchy, less specific to more specific.
- There must be *covariance* of the return types in the subtype.
    - *with* : relationship preservation
- No new *exceptions* can be thrown by the subtype unless they are part of the existing exception hierarchy.
    - Different implementations should not throw different exceptions so clients have should not know each new exception introduced, unify with common base exceptions.

# I
Interface segregation principle

# D
Dependency inversion principle
