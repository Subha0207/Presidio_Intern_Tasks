import random

# Function to set the secret word
def set_secret_word():
    return 'bowl'  

# Function to play the Cows and Bulls game
def play_cows_and_bulls(secret_word):
    print("Welcome to Cows and Bulls!")
    print("Try to guess the 4-letter word.")
    print("Type 'exit' to quit the game.\n")

    guesses = 0
    while True:
        guess = input("Enter your guess: ").lower()

        if guess == 'exit':
            print(f"The secret word was '{secret_word}'. Better luck next time!")
            break
        
        if len(guess) != 4 or not guess.isalpha():
            print("Please enter a valid 4-letter word.")
            continue

        cows = 0
        bulls = 0
        for i in range(4):
            if guess[i] == secret_word[i]:
                cows += 1
            elif guess[i] in secret_word:
                bulls += 1
        
        guesses += 1
        if cows == 4:
            print(f"Congratulations! You guessed the word '{secret_word}' in {guesses} guesses.")
            break
        else:
            print(f"Guess {guesses}: Cows = {cows}, Bulls = {bulls}")

if __name__ == "__main__":
    secret_word = set_secret_word()
    play_cows_and_bulls(secret_word)
