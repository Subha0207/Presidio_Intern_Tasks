# Topics
# (1) Initial setup of python
# 2) Identifying the IDE/Development environment
# 3) Basics
#     Understanding Execution
# Taking user input
name = input("Enter your name: ")

#     Output
print("Hello, " + name + "!")

#     Datatypes
integer_value = 10
float_value = 20.5
string_value = "Hello, World!"
list_value = [1, 2, 3, 4, 5]
dictionary_value = {"name": "Alice", "age": 25}

print(type(integer_value))  # <class 'int'>
print(type(float_value))    # <class 'float'>
print(type(string_value))   # <class 'str'>
print(type(list_value))     # <class 'list'>
print(type(dictionary_value)) # <class 'dict'>

#     Operators

# Arithmetic operators
a = 10
b = 5
print(a + b)  # Addition: 15
print(a - b)  # Subtraction: 5
print(a * b)  # Multiplication: 50
print(a / b)  # Division: 2.0

# Comparison operators
print(a == b)  # Equal: False
print(a != b)  # Not equal: True
print(a > b)   # Greater than: True
print(a < b)   # Less than: False

# Logical operators
print(a > 0 and b > 0)  # Logical AND: True
print(a > 0 or b < 0)   # Logical OR: True
print(not(a > 0))       # Logical NOT: False

# Assignment operators
c = 10
c += 5  # Equivalent to c = c + 5
print(c)  # 15

#     Conditional statements
# If-else statement
age = 18
if age >= 18:
    print("You are an adult.")
else:
    print("You are a minor.")

#     Iterations
# For loop
for i in range(5):
    print(i)

# While loop
count = 0
while count < 5:
    print(count)
    count += 1

#     Methods
class Person:
    def __init__(self, name):
        self.name = name
    
    def greet(self):
        return f"Hello, {self.name}!"

# Creating an instance of the class
person = Person("Alice")
print(person.greet())  # Output: Hello, Alice!
#__init__ method is a special method that is called when an instance (object) of a class is created. 
#When you prefix a string with f or F, it becomes an f-string. Within the f-string, any expression inside curly braces {} will be evaluated and replaced with its result.

# 	Parameter
def add(a, b):
    return a + b
# 	Returns
# Calling the function with parameters
result = add(10, 5)
print(result)  # Output: 15


#     List and Indexing
# Creating a list
fruits = ["apple", "banana", "cherry"]

# Accessing items by index
print(fruits[0])  # Output: apple
print(fruits[1])  # Output: banana

# Modifying an item
fruits[1] = "blueberry"
print(fruits)  # Output: ['apple', 'blueberry', 'cherry']

# Slicing a list
print(fruits[0:2])  # Output: ['apple', 'blueberry']

