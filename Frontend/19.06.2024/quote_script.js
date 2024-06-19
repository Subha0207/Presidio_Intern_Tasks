let quotes = [];
let quotesPerPage = 5;
let currentPage = 1;

async function fetchQuotes() {
  try {
    const response = await fetch('https://dummyjson.com/quotes');
    const data = await response.json();
    quotes = data.quotes;
    displayQuotes(); // Display quotes initially
  } catch (error) {
    console.error('Error fetching quotes:', error);
  }
}

function displayQuotes(filterText = null, sortOption = 'ascending') {
  const quoteContainer = document.getElementById('quote-container');
  quoteContainer.innerHTML = '';

  let filteredQuotes = quotes;
  if (filterText) {
    const lowerCaseFilter = filterText.toLowerCase();
    filteredQuotes = quotes.filter(quote => {
      return quote.quote.toLowerCase().includes(lowerCaseFilter) ||
             quote.author.toLowerCase().includes(lowerCaseFilter);
    });
  }

  if (filteredQuotes.length === 0) {
    // Display an alert if no quotes are found
    alert(`No quotes found for author '${filterText}'`);
    return;
  }

  // Sort the filtered quotes
  filteredQuotes.sort((a, b) => {
    const authorA = a.author.toLowerCase();
    const authorB = b.author.toLowerCase();
    if (sortOption === 'ascending') {
      return authorA.localeCompare(authorB);
    } else {
      return authorB.localeCompare(authorA);
    }
  });

  const start = (currentPage - 1) * quotesPerPage;
  const end = start + quotesPerPage;
  const paginatedQuotes = filteredQuotes.slice(start, end);

  paginatedQuotes.forEach(quote => {
    const quoteElement = document.createElement('div');
    quoteElement.className = 'quote-card';
    quoteElement.innerHTML = `<p>"${quote.quote}"</p><p>- ${quote.author}</p>`;
    quoteContainer.appendChild(quoteElement);
  });

  document.getElementById('page-number').innerText = currentPage;
}

function nextPage() {
  const totalPages = Math.ceil(quotes.length / quotesPerPage);
  if (currentPage < totalPages) {
    currentPage++;
    displayQuotes(document.getElementById('search-input').value.trim(), document.getElementById('sort-quotes').value);
  }
}

function previousPage() {
  if (currentPage > 1) {
    currentPage--;
    displayQuotes(document.getElementById('search-input').value.trim(), document.getElementById('sort-quotes').value);
  }
}

function searchQuotes() {
  currentPage = 1; // Reset to the first page when searching
  displayQuotes(document.getElementById('search-input').value.trim(), document.getElementById('sort-quotes').value);
}

window.onload = function() {
  fetchQuotes();
};

function sortQuotes() {
  displayQuotes(document.getElementById('search-input').value.trim(), document.getElementById('sort-quotes').value);
}
