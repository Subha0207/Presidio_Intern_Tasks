# Credit card validation - Luhn check algorithm

'''
Steps involved in the Luhn algorithm
Let’s understand the algorithm with an example: 
Consider the example of an account number “79927398713“. 

Step 1 – Starting from the rightmost digit, double the value of every second digit, 
Step 2 – If doubling of a number results in a two digit number i.e greater than 9(e.g., 6 × 2 = 12),
then add the digits of the product (e.g., 12: 1 + 2 = 3, 15: 1 + 5 = 6), to get a single digit number. 
Step 3 – Now take the sum of all the digits.
Step 4 – If the total modulo 10 is equal to 0 (if the total ends in zero) 
then the number is valid according to the Luhn formula; else it is not valid.
 
'''

def luhn_check(card_number):
    # Convert the card number to a list of integers
    digits = [int(digit) for digit in str(card_number)]
    
    # Step 1: Double every second digit from the right (excluding the check digit)
    #getting every second number from the reverse starting from second last number
    doubled = digits[-2::-2]
    for i in range(len(doubled)):
        doubled_digit = 2 * doubled[i]
        if doubled_digit > 9:
            doubled_digit -= 9
        doubled[i] = doubled_digit
    
    # Combine the unchanged and doubled parts
    combined = doubled + digits[-1::-2]
    
    # Step 2: Sum all the digits
    total_sum = sum(combined)
    
    # Step 3: Check if the sum modulo 10 equals 0
    return total_sum % 10 == 0

# Example usage:
card_number = 79927398713
print(f"Card number {card_number} is valid: {luhn_check(card_number)}")  # Output: False (according to the example)

# Test with a valid number
valid_card_number = 79927398710
print(f"Card number {valid_card_number} is valid: {luhn_check(valid_card_number)}")  # Output: True
