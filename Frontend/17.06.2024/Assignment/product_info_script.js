// Function to get URL parameters
function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    const regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    const results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
}

// Get the product ID from URL
const productId = getUrlParameter('id');

fetch(`https://dummyjson.com/products/${productId}`)
    .then(res => res.json())
    .then(product => {
        // Populate images
        const imagesContainer = document.getElementById('info-images');
        product.images.forEach((src, index) => {
            const img = document.createElement('img');
            img.src = src;
            img.alt = `Image ${index + 1}`;
            imagesContainer.appendChild(img);
        });
        document.getElementById('large-image').src = product.thumbnail;

        // Populate product info
        document.getElementById('title').innerText = product.title;
        document.getElementById('discounted-price').innerText = `$${(product.price * (1 - product.discountPercentage / 100)).toFixed(2)}`;
        document.getElementById('original-price').innerText = `$${product.price}`;
        document.getElementById('availability-status').innerText = `Availability: ${product.availabilityStatus}`;
        document.getElementById('stock').innerText = `Stock: ${product.stock}`;
        document.getElementById('warranty').innerText = product.warrantyInformation;
        document.getElementById('return-policy').innerText = product.returnPolicy;
        document.getElementById('shipping-info').innerText = product.shippingInformation;
        document.getElementById('brand').innerText = product.brand;
        document.getElementById('product-title').innerText = product.title;
        document.getElementById('weight').innerText = `${product.weight} g`;
        document.getElementById('width').innerText = `Width: ${product.dimensions.width} cm`;
        document.getElementById('height').innerText = `Height: ${product.dimensions.height} cm`;
        document.getElementById('depth').innerText = `Depth: ${product.dimensions.depth} cm`;

        // Populate reviews
   

        const reviewsContainer = document.getElementById('reviews');
        product.reviews.forEach(review => {
            const reviewDiv = document.createElement('div');
            reviewDiv.classList.add('customer');
            reviewDiv.innerHTML = `
        <p><strong>Name:</strong> ${review.reviewerName}</p>
        <p><strong>Email:</strong> ${review.reviewerEmail}</p>
        <span><strong>Rating:</strong> ${review.rating} stars</span>
        <p><strong>Date:</strong> ${new Date(review.date).toLocaleDateString()}</p>
        <p><strong>Comment:</strong> ${review.comment}</p>
    `;
            reviewsContainer.appendChild(reviewDiv);
        });

    })
    .catch(error => {
        console.error('Error fetching product details:', error);
    });
