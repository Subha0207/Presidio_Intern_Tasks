import re
from datetime import datetime
import pandas as pd
from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas

# Function to get and validate employee details
def get_employee_details():
    while True:
        name = input("Enter Name: ")
        if not re.match(r"^[A-Za-z ]*$", name):
            print("Invalid name. Please enter alphabetic characters only.")
            continue

        dob = input("Enter Date of Birth (YYYY-MM-DD): ")
        try:
            dob = datetime.strptime(dob, "%Y-%m-%d")
        except ValueError:
            print("Invalid date format. Please use YYYY-MM-DD.")
            continue

        phone = input("Enter Phone Number: ")
        if not re.match(r"^\d{10}$", phone):
            print("Invalid phone number. Please enter a 10-digit number.")
            continue

        email = input("Enter Email: ")
        if not re.match(r"[^@]+@[^@]+\.[^@]+", email):
            print("Invalid email format. Please enter a valid email address.")
            continue

        age = calculate_age(dob)
        return {'Name': name, 'DOB': dob.strftime("%Y-%m-%d"), 'Phone': phone, 'Email': email, 'Age': age}

# Function to calculate age from DOB
def calculate_age(dob):
    today = datetime.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age

# Function to save data to a text file
def save_to_text(employee_data, filename="employee_data.txt"):
    with open(filename, 'a') as file:
        for emp in employee_data:
            file.write(f"{emp['Name']}, {emp['DOB']}, {emp['Phone']}, {emp['Email']}, {emp['Age']}\n")

# Function to save data to an Excel file
def save_to_excel(employee_data, filename="employee_data.xlsx"):
    df = pd.DataFrame(employee_data)
    try:
        existing_df = pd.read_excel(filename)
        df = pd.concat([existing_df, df], ignore_index=True)
    except FileNotFoundError:
        pass
    df.to_excel(filename, index=False)

# Function to save data to a PDF file
def save_to_pdf(employee_data, filename="employee_data.pdf"):
    c = canvas.Canvas(filename, pagesize=letter)
    width, height = letter
    y = height - 40
    for emp in employee_data:
        c.drawString(30, y, f"Name: {emp['Name']}")
        y -= 20
        c.drawString(30, y, f"DOB: {emp['DOB']}")
        y -= 20
        c.drawString(30, y, f"Phone: {emp['Phone']}")
        y -= 20
        c.drawString(30, y, f"Email: {emp['Email']}")
        y -= 20
        c.drawString(30, y, f"Age: {emp['Age']}")
        y -= 40
        if y < 40:  # Check if we need to add a new page
            c.showPage()
            y = height - 40
    c.save()

# Function to save employee data in the chosen format
def save_employee_data(employee_data):
    print("Choose a format to save the data:")
    print("1. Text")
    print("2. Excel")
    print("3. PDF")
    choice = input("Enter your choice (1/2/3): ")

    if choice == '1':
        save_to_text(employee_data)
    elif choice == '2':
        save_to_excel(employee_data)
    elif choice == '3':
        save_to_pdf(employee_data)
    else:
        print("Invalid choice. Data not saved.")

# Function to read bulk data from an Excel file
def read_bulk_from_excel(filename):
    try:
        df = pd.read_excel(filename)
        employees = df.to_dict(orient='records')
        for employee in employees:
            employee['Age'] = calculate_age(datetime.strptime(employee['DOB'], "%Y-%m-%d"))
        return employees
    except FileNotFoundError:
        print(f"File {filename} not found.")
        return []

# Main function to present the menu and handle user choices
def main():
    while True:
        print("1. Enter new employee data")
        print("2. Bulk read from Excel")
        print("3. Exit")
        choice = input("Enter your choice (1/2/3): ")

        if choice == '1':
            employee_data = [get_employee_details()]
            save_employee_data(employee_data)
        elif choice == '2':
            filename = input("Enter the Excel file name (with .xlsx extension): ")
            employees = read_bulk_from_excel(filename)
            save_employee_data(employees)
        elif choice == '3':
            break
        else:
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main()
