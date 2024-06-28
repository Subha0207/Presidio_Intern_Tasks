def longest_substring_without_repeating_chars(s):
    # Initialize variables
    max_length = 0
    start = 0
    char_set = set()
    longest_substring = ""

    # Iterate through the string using a sliding window approach
    for end in range(len(s)):
        while s[end] in char_set:
            char_set.remove(s[start])
            start += 1
        char_set.add(s[end])
        current_length = end - start + 1
        if current_length > max_length:
            max_length = current_length
            longest_substring = s[start:end + 1]

    return longest_substring

# Example usage:
input_string = input("Enter the string:")
result = longest_substring_without_repeating_chars(input_string)
print(f"The longest substring without repeating characters in '{input_string}' is '{result}'")
