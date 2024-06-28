# README: Python Basics

This README provides an overview of some fundamental concepts in Python: string manipulation, functions, tuples, dictionaries, and sets. Each section includes basic explanations and code examples.

## Table of Contents

1. [String Manipulation](#string-manipulation)
2. [Functions](#functions)
3. [Tuples](#tuples)
4. [Dictionaries](#dictionaries)
5. [Sets](#sets)

## String Manipulation

Strings in Python are sequences of characters. You can manipulate strings using various methods.

### Examples:

#### Concatenation
```python
string1 = "Hello"
string2 = "World"
result = string1 + " " + string2
print(result)  # Output: Hello World
```

#### Slicing
```python
string = "Hello World"
print(string[0:5])  # Output: Hello
```

#### Methods
```python
string = "hello world"
print(string.upper())  # Output: HELLO WORLD
print(string.replace("world", "there"))  # Output: hello there
```

## Functions

Functions are blocks of reusable code that perform a specific task. They are defined using the `def` keyword.

### Syntax:
```python
def function_name(parameters):
    # code block
    return value
```

### Examples:
```python
def greet(name):
    return f"Hello, {name}!"

print(greet("Alice"))  # Output: Hello, Alice!
```

## Tuples

Tuples are immutable sequences in Python, meaning they cannot be changed after creation. They are defined using parentheses `()`.

### Examples:
```python
tuple1 = (1, 2, 3)
print(tuple1[0])  # Output: 1

# Unpacking
a, b, c = tuple1
print(a, b, c)  # Output: 1 2 3
```

## Dictionaries

Dictionaries are collections of key-value pairs. They are defined using curly braces `{}`.

### Examples:
```python
dict1 = {"name": "Alice", "age": 25}
print(dict1["name"])  # Output: Alice

# Adding a new key-value pair
dict1["city"] = "New York"
print(dict1)  # Output: {'name': 'Alice', 'age': 25, 'city': 'New York'}
```

## Sets

Sets are unordered collections of unique elements. They are defined using curly braces `{}` or the `set()` function.

### Examples:
```python
set1 = {1, 2, 3, 4}
print(set1)  # Output: {1, 2, 3, 4}

# Adding an element
set1.add(5)
print(set1)  # Output: {1, 2, 3, 4, 5}

# Removing an element
set1.remove(3)
print(set1)  # Output: {1, 2, 4, 5}
```

## Conclusion

This guide covered basic concepts and examples of string manipulation, functions, tuples, dictionaries, and sets in Python. 