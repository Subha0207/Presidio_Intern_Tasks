# Take 10 numbers and find the average of all the prime numbers in the collection

def is_prime(n):
    if n <= 1:
        return False 
    for i in range(2, n):
        if n % i == 0:
            return False  
    return True  
    
sum_primes = 0
count_primes = 0

# Take 10 numbers from user input
for i in range(1, 11):
    number = int(input(f"Enter number {i}: "))
    if is_prime(number):
        sum_primes += number
        count_primes += 1

if count_primes > 0:
    average_prime = sum_primes / count_primes
    print(f"Average of prime numbers entered: {average_prime}")
else:
    print("No prime numbers entered.")
