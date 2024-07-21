const foundWords = [];
const letters = ['S', 'I', 'A', 'T', 'E', 'B', 'P'];
const words = ['BITE', 'PEST', 'BETA', 'BEST', 'PEAT', 'TAPE', 'SEAT'];
const centerLetter = 'T';

document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.hex').forEach(hex => {
        hex.addEventListener('click', () => {
            const input = document.getElementById('wordInput');
            input.value += hex.textContent;
        });
    });
});

function checkWord() {
    const input = document.getElementById('wordInput');
    const word = input.value.toUpperCase();

    if (word.includes(centerLetter) && isValidWord(word) && !foundWords.includes(word)) {
        foundWords.push(word);
        document.getElementById('wordCount').textContent = `You have found ${foundWords.length} words`;
        updateProgress();
    }

    input.value = '';
    console.log(foundWords); 
}

function isValidWord(word) {
    return word.length > 3 &&
           word.split('').every(letter => letters.includes(letter)) &&
           words.includes(word);
}

function updateProgress() {
    const progressBarInner = document.querySelector('.progress-bar-inner');
    const stepElements = document.querySelectorAll('.step');

    const progress = (foundWords.length / words.length) * 100;
    progressBarInner.style.width = `${progress}%`;

    stepElements.forEach((step, index) => {
        if (index < foundWords.length) {
            step.classList.add('completed');
        } else {
            step.classList.remove('completed');
        }
    });
}
