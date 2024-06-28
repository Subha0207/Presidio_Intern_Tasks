#Sort score and name of players print the top 10
players_scores = {
    'Alice': 95,
    'Bob': 87,
    'Charlie': 92,
    'David': 78,
    'Emma': 85,
    'Frank': 90,
    'Grace': 83,
    'Henry': 88,
    'Ivy': 91,
    'Jack': 82,
    'Kate': 96,
    'Liam': 79,
    'Mia': 84,
    'Noah': 89,
    'Olivia': 97,
    'Peter': 86,
    'Quinn': 94,
    'Rose': 80,
    'Sam': 93,
    'Tom': 81
}


players_list = list(players_scores.items())

# Sort players_list by score in descending order
players_list.sort(key=lambda x: x[1], reverse=True)

# Print the top 10 players
print("Top 10 Players:")
for i, (player, score) in enumerate(players_list[:10], start=1):
    print(f"{i}. {player}: {score}")


#lambda x: x[1]: This is an anonymous (lambda) function that takes an argument x (which represents each key-value pair in the dictionary).
#  The expression x[1] refers to the value associated with the key (i.e., the player’s score).
#  So, this lambda function extracts the score for each player.
