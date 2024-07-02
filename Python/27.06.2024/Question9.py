def find_permutations(s):
    # Base case: if the string is empty, return an empty list
    if len(s) == 0:
        return ['']
    
    # List to store all permutations
    permutations = []
    
    # Loop through the string
    for i in range(len(s)):
       
        current_char = s[i]
        
       
        remaining_chars = s[:i] + s[i+1:]
        
       
        for p in find_permutations(remaining_chars):
            permutations.append(current_char + p)
    
    return permutations

# Get input from user
input_string = input("Enter a string: ")

# Find all permutations
permutations = find_permutations(input_string)

# Display the permutations
print(f"All permutations of the string '{input_string}':")
for perm in permutations:
    print(perm)
