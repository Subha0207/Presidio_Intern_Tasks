def print_pyramid(n):
    for i in range(1, n+1):
        # Print leading spaces
        for j in range(n - i):
            print(" ", end="")
        
        # Print stars
        for k in range(2 * i - 1):
            print("*", end="")
        
        # Move to the next line
        print()

# Example usage:
print_pyramid(3)
