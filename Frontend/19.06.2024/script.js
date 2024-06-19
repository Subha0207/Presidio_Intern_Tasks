document.addEventListener("DOMContentLoaded", () => {
    const text = "This project showcases a collection of inspiring quotes from various authors.";
    const container = document.getElementById("animated-text");
    
    text.split(" ").forEach((word, index) => {
      const span = document.createElement("span");
      span.textContent = word + " ";
      span.style.animationDelay = `${index * 0.3}s`;
      span.classList.add("animate-text");
      container.appendChild(span);
    });
  });


  