fetch('https://dummyjson.com/products')
    .then(res => res.json())
    .then(data => {
        const products = data.products;

        const productContainer = document.getElementById('product-container');

        products.forEach(product => {
            const productDiv = document.createElement('div');
            productDiv.classList.add('product');

            const imgContainer = document.createElement('div');
            imgContainer.classList.add('img-container');
            const img = document.createElement('img');
            img.src = product.thumbnail;
            img.alt = product.title;
            imgContainer.appendChild(img);
            productDiv.appendChild(imgContainer);

            const categoryDiv = document.createElement('div');
            categoryDiv.classList.add('category');
            categoryDiv.textContent = product.category;
            productDiv.appendChild(categoryDiv);

            const brandH4 = document.createElement('h4');
            brandH4.textContent = product.brand;
            productDiv.appendChild(brandH4);

            const titleA = document.createElement('a');
            titleA.href = `product_info.html?id=${product.id}`; // To include product ID
            titleA.textContent = product.title;
            productDiv.appendChild(titleA);

            const ratingDiv = document.createElement('div');
            ratingDiv.classList.add('rating');
            const filledStars = Math.floor(product.rating);
            for (let i = 0; i < filledStars; i++) {
                const starIcon = document.createElement('i');
                starIcon.classList.add('fas', 'fa-star');
                ratingDiv.appendChild(starIcon);
            }
            if (product.rating - filledStars >= 0.5) {
                const halfStarIcon = document.createElement('i');
                halfStarIcon.classList.add('fas', 'fa-star-half-alt');
                ratingDiv.appendChild(halfStarIcon);
            }
            const emptyStars = 5 - Math.ceil(product.rating);
            for (let i = 0; i < emptyStars; i++) {
                const starIcon = document.createElement('i');
                starIcon.classList.add('fas', 'fa-star', 'empty-star');
                ratingDiv.appendChild(starIcon);
            }
            const ratingText = document.createElement('span');
            ratingText.classList.add('rating-text');
            ratingText.textContent = `(${product.rating.toFixed(2)} stars)`;
            ratingDiv.appendChild(ratingText);
            productDiv.appendChild(ratingDiv);

            const priceContainer = document.createElement('div');
            priceContainer.classList.add('price-container');

            const sellingPrice = document.createElement('h2');
            sellingPrice.id = 'sellingPrice';
            sellingPrice.textContent = `$${product.price.toFixed(2)}`;
            priceContainer.appendChild(sellingPrice);

            const originalPrice = document.createElement('span');
            originalPrice.classList.add('original-price');
            originalPrice.textContent = `MRP: $${(product.price * (100 / (100 - product.discountPercentage))).toFixed(2)}`;
            priceContainer.appendChild(originalPrice);

            const discountPercent = document.createElement('span');
            discountPercent.classList.add('discount-percent');
            discountPercent.textContent = `(${product.discountPercentage}% off)`;
            priceContainer.appendChild(discountPercent);

            productDiv.appendChild(priceContainer);

            productContainer.appendChild(productDiv);
        });
    })
    .catch(error => {
        console.error('Error fetching and displaying products:', error);
    });
