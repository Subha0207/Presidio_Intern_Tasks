#Take name and gender print greet with salutation
name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ")

if gender == "M":
    prefix = "Mr."
else:
    prefix = "Ms."

print(f"Hello, {prefix} {name}!")
