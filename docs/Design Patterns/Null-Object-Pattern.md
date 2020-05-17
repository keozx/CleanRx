### In a nutshell
Allows to delegate null checking to the service class instead of the client, avoiding null checks everywhere an instance is accessed. In essence is a Strategy pattern but with a very specific purpose.

https://deviq.com/null-object-pattern/

### Some advantages
* Avoid Cascading Nulls syntax to write less obfuscated code
* Reduces complexity in client calls specially when chaining many (?) operators

### Anti patterns
* IsNull property anti-pattern, defeats the purpose of the pattern

Reference:
(1) McLean, H. G. (2017). *Adaptive Code: Agile coding with design patterns and SOLID principles, 2nd Edition*. Microsoft Press