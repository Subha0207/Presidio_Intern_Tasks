function validateLogin(username, password) {
    var users = [
        { username: 'user1', password: 'password1' },
        { username: 'user2', password: 'password2' }
    ];
    
    return users.some(function(user) {
        return user.username === username && user.password === password;
    });
}

function handleLogin(event) {
    event.preventDefault();
    
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var errorMessage = document.getElementById('error-message');
    
    var isValid = validateLogin(username, password);
    
    if (isValid) {
        errorMessage.textContent = 'Login successful!';
        errorMessage.style.color = 'green';
        errorMessage.style.display = 'block';
    } else {
        errorMessage.textContent = 'Invalid username or password!';
        errorMessage.style.color = 'red';
        errorMessage.style.display = 'block';
    }
}

document.getElementById('loginForm').addEventListener('submit', handleLogin);

// Export the function for testing
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { validateLogin, handleLogin };
}
