#Find if the given number is prime

def is_prime(n):
    if n <= 1:
        return False  # Numbers less than or equal to 1 are not prime
    for i in range(2, n):
        if n % i == 0:
            return False  
    return True  # If no divisors found, n is prime

# Example usage:
number = int(input("Enter a number: "))
if is_prime(number):
    print(f"{number} is a prime number.")
else:
    print(f"{number} is not a prime number.")
