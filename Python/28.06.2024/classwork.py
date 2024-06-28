#String manipulating
'''
1)to Concatenate Strings
You can use the + operator to concatenate strings.'''
word1 = 'New '
word2 = 'York'

print(word1 + word2)

#NewYork

'''2)to Select a char
To select a char, use [] and specify the position of the char.'''

word = "Rio de Janeiro"
char=word[0]
print(char)

#R
'''3)to Get the Size of a String
The len() function returns the length of a string.
'''

len('Rio')
#3
'''4)to Replace Part of a String
The replace() method replaces a part of the string with another. As an example, let's replace 'Rio' for 'Mar'.
'''

'Rio de Janeiro'.replace('Rio', 'Mar')
#'Mar de Janeiro'

'''
5)to Count
Specify what to count as an argument.
Here it counts the space
'''

word = "Rio de Janeiro"
print(word.count(' '))
#2

'''6)to Repeat a String
You can use the * symbol to repeat a string.

Here we are multiplying the word "Tokyo" by 3.'''

words = "Tokyo" * 3 
print(words)
#TokyoTokyoTokyo

#7)to Split a String in Python

my_phrase = "let's go to the beach"
my_words = my_phrase.split(" ")

for word in my_words:
    print(word)
#output:
#let's
#go
#to
#the
#beach

print(my_words)
#output:
#["let's", 'go', 'to', 'the', 'beach']
#---------------------------------------------------
my_csv = "mary;32;australia;mary@email.com"
my_data = my_csv.split(";")

for data in my_data:
    print(data)

#output:
#mary
#32
#australia
#mary@email.com

print(my_data[3])
#output:
# mary@email.com

'''
8)regular expression operations.

The + symbol is called a quantifier and is read as 'one or more'. 
This means that it will consider, in this case,
one or more white spaces since it is positioned right after the \s.'''

import re

phrase = ' Do   or do    not   there    is  no try   '

phrase_no_space = re.sub(r'\s+', '', phrase)

print(phrase)
# Do   or do    not   there    is  no try   

print(phrase_no_space)
#Doordonotthereisnotry

'''
9)Triple Quotes
To handle multiline strings in Python you use triple quotes, either single or double.

This first example uses double quotes.'''

long_text = """This is a multiline,

a long string with lots of text,

I'm wrapping it in triple quotes to make it work."""

print(long_text)
#output:
#This is a multiline,
#
#a long string with lots of text,
#
#I'm wrapping it in triple quotes to make it work.

'''

10)lstrip()
Use the lstrip() method to remove spaces from the beginning of a string.
'''

regular_text = "   This is a regular text."

no_space_begin_text = regular_text.lstrip()

print(regular_text)
#'   This is a regular text.'

print(no_space_begin_text)
#'This is a regular text.'

'''
11)rstrip()
regular_text = "This is a regular text.   "
'''

no_space_end_text = regular_text.rstrip()

print(regular_text)
#'This is a regular text.   '

print(no_space_end_text)
#'This is a regular text.'

'''
12)strip()
Use the strip() method to remove spaces from the beginning and the end of a string.
'''
regular_text = "  This is a regular text.   "

no_space_text = regular_text.strip()

print(regular_text)
#'  This is a regular text.   '

print(no_space_text)
#'This is a regular text.'

#13)lower() method to transform a whole string into lowercase.

#14)upper() method to transform a whole string into uppercase.

#15)title() method to transform the first letter in each word into upper case and the rest of characters into lower case.

#16)swapcase() method to transform the upper case characters into lower case and vice versa.

'''
17)to Reverse a String in Python
To reverse a string, use the slice syntax:
'''

my_string = "ferrari"

my_string_reversed = my_string[::-1]

print(my_string)

print(my_string_reversed)

'''
18)Basic Slicing Notation
Let's say we have an array called 'list'.

list[start:stop:step]
'''

word='movie'
#To get the first two characters:

sliced = word[:2]
print(sliced)
#mo

#The last item:

sliced = word[-1]
print(sliced)
#e

#Skipping letters with a step of 2:

sliced = word[::2]
print(sliced)
#mve


#19)find(): How to Check if a String Has a Certain Substring in Python'''

phrase = "This is a regular text"

print(phrase.find('This'))
#output:0


#Functions 
'''
Functions are blocks of reusable code that perform a specific task. 
They are defined using the def keyword.'''
#SYNTAX:
def function_name(parameters):
    # code block
    return value
#EXAMPLE:
def greet(name):
    return f"Hello, {name}!"

print(greet("Alice"))  
# Output: Hello, Alice!


#Tuples,
'''
Tuple items are ordered, unchangeable, and allow duplicate values.

Tuple items are indexed, the first item has index [0], the second item has index [1] etc.

Ordered
When we say that tuples are ordered, it means that the items have a defined order, and that order will not change.

Unchangeable
Tuples are unchangeable, meaning that we cannot change, add or remove items after the tuple has been created.

Allow Duplicates
Since tuples are indexed, they can have items with the same value:
'''
tuple1 = (1, 2, 3)
print(tuple1[0])  # Output: 1

# Unpacking
a, b, c = tuple1
print(a, b, c)  # Output: 1 2 3


#Dictionaries
''''
Dictionaries are collections of key-value pairs. They are defined using curly braces {}.'''
dict1 = {"name": "Alice", "age": 25}
print(dict1["name"])  # Output: Alice

# Adding a new key-value pair
dict1["city"] = "New York"
print(dict1)  # Output: {'name': 'Alice', 'age': 25, 'city': 'New York'}


#Sets  

''''
Sets are unordered collections of unique elements. 
They are defined using curly braces {} or the set() function.
'''
set1 = {1, 2, 3, 4}
print(set1)  # Output: {1, 2, 3, 4}

# Adding an element
set1.add(5)
print(set1)  # Output: {1, 2, 3, 4, 5}

# Removing an element
set1.remove(3)
print(set1)  # Output: {1, 2, 4, 5}

