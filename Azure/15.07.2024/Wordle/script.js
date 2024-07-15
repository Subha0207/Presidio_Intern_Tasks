const wordToGuess = "hello";
let attemptsLeft = 5;
let guessedLetters = [];
let currentGuess = [];
let currentRow = 0;

const wordDisplay = document.getElementById('wordDisplay');
const resultDiv = document.getElementById('result');
const attemptsSpan = document.getElementById('attempts');
const keyboardContainer = document.getElementById('keyboard');

// Initialize word display with underscores
for (let i = 0; i < 25; i++) {
    const letterSpan = document.createElement('span');
    letterSpan.textContent = ' ';
    letterSpan.classList.add('letter');
    wordDisplay.appendChild(letterSpan);
}

// Generate keyboard buttons dynamically
const alphabet = 'abcdefghijklmnopqrstuvwxyz';
for (let char of alphabet) {
    const keyButton = document.createElement('button');
    keyButton.textContent = char.toUpperCase();
    keyButton.classList.add('key');
    keyButton.addEventListener('click', () => {
        handleKeyboardClick(char.toUpperCase());
    });
    keyboardContainer.appendChild(keyButton);
}

function handleKeyboardClick(letter) {
    if (currentGuess.length < 5) {
        const emptyIndex = currentRow * 5 + currentGuess.length;
        wordDisplay.children[emptyIndex].textContent = letter;
        currentGuess.push(letter);
        if (currentGuess.length === 5) {
            handleGuess();
        }
    }
}

function handleGuess() {
    const guess = currentGuess.join('').toLowerCase();

    if (guessedLetters.includes(guess)) {
        alert('You already guessed that word!');
        resetCurrentGuess();
        return;
    }

    guessedLetters.push(guess);
    attemptsLeft--;
    attemptsSpan.textContent = attemptsLeft;

    let correctLetters = 0;

    for (let i = 0; i < 5; i++) {
        const letter = currentGuess[i].toLowerCase();
        const index = currentRow * 5 + i;

        if (letter === wordToGuess[i]) {
            wordDisplay.children[index].classList.add('correct-position');
            correctLetters++;
        } else if (wordToGuess.includes(letter)) {
            wordDisplay.children[index].classList.add('wrong-position');
        }
    }

    if (correctLetters === 5) {
        resultDiv.textContent = 'Congratulations! You guessed the word!';
        resultDiv.style.color = 'green';
        disableGameControls();
    } else if (attemptsLeft === 0) {
        resultDiv.textContent = 'Game over! You ran out of attempts.';
        resultDiv.style.color = 'red';
        disableGameControls();
    }

    currentGuess = [];
    currentRow++;
}

function resetCurrentGuess() {
    for (let i = 0; i < 5; i++) {
        const index = currentRow * 5 + i;
        wordDisplay.children[index].textContent = ' ';
    }
    currentGuess = [];
}

function disableGameControls() {
    document.querySelectorAll('.key').forEach(key => key.disabled = true);
}
