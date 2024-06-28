# Print the list of prime numbers up to a given number
def is_prime(num):
    # Handle cases for numbers less than 2
    if num <= 1:
        return False
    # 2 and 3 are prime numbers
    if num <= 3:
        return True
    # Exclude even numbers
    if num % 2 == 0:
        return False
    # Check for prime numbers
    i = 3
    while i * i <= num:
        if num % i == 0:
            return False
        i += 2
    return True

def find_primes_up_to(limit):
    prime_numbers = []
    for num in range(2, limit + 1):
        if is_prime(num):
            prime_numbers.append(num)
    return prime_numbers

# Get upper limit from user input
try:
    upper_limit = int(input("Enter the upper limit to find prime numbers: "))
    primes_list = find_primes_up_to(upper_limit)
    print(f"Prime numbers up to {upper_limit}:")
    print(primes_list)
except ValueError:
    print("Invalid input. Please enter a valid integer.")
