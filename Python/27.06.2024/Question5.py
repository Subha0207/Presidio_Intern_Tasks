import re


def validate_date_of_birth(dob):
    pattern = r'\d{2}/\d{2}/\d{4}'
    return re.match(pattern, dob)


def validate_phone_number(phone):
    pattern = r'\d{10}'  # Assuming phone number should be 10 digits
    return re.match(pattern, phone)


def validate_name(name):
    return name.strip() and name.isalpha() and ' ' not in name


def validate_age(age):
    return age.isdigit() and 1 <= int(age) <= 150

# Main program
name = ""
age = ""
dob = ""
phone = ""

while not validate_name(name):
    name = input("Enter your name: ")
    if not validate_name(name):
        print("Invalid name format. Please enter alphabetic characters only without spaces.")
        
while not validate_age(age):
    age = input("Enter your age: ")
    if not validate_age(age):
        print("Invalid age format. Please enter a valid age between 1 and 150.")
        
while not validate_date_of_birth(dob):
    dob = input("Enter your Date of Birth (dd/mm/yyyy): ")
    if not validate_date_of_birth(dob):
        print("Invalid date of birth format. Please use dd/mm/yyyy.")
        
while not validate_phone_number(phone):
    phone = input("Enter your mobile number: ")
    if not validate_phone_number(phone):
        print("Invalid phone number. Please enter a 10-digit number without spaces or special characters.")

# Print details in proper format
print(f"""
--- Details ---
Name:  {name}
Age:   {age}
DOB:   {dob}
Phone: {phone}
""")
