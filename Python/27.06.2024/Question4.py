#Take name, age, date of birth and phone print details in proper format

name = input("Enter your name: ")
age = input("Enter your age: ")
dob = input("Enter your Date of Birth (dd/mm/yyyy): ")
phone = input("Enter your mobile number: ")

print(f"""
--- Details ---
Name:  {name}
Age:   {age}
DOB:   {dob}
Phone: {phone}
""")

