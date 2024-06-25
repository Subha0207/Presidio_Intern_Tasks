const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');

test('should display error message for invalid credentials', (done) => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../script.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const { document } = dom.window;

    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const errorMessage = document.getElementById('error-message');

    usernameInput.value = 'invaliduser';
    passwordInput.value = 'invalidpassword';

    const form = document.getElementById('loginForm');
    const submitEvent = new dom.window.Event('submit');
    form.dispatchEvent(submitEvent);

    // Using a small timeout to wait for the DOM to update
    setTimeout(() => {
        expect(errorMessage.style.display).toBe('block');
        expect(errorMessage.textContent).toBe('Invalid username or password!');
        expect(errorMessage.style.color).toBe('red');
        done();
    }, 100);
});

test('should display success message for valid credentials', (done) => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../script.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const { document } = dom.window;

    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const errorMessage = document.getElementById('error-message');

    usernameInput.value = 'user1';
    passwordInput.value = 'password1';

    const form = document.getElementById('loginForm');
    const submitEvent = new dom.window.Event('submit');
    form.dispatchEvent(submitEvent);

    // Using a small timeout to wait for the DOM to update
    setTimeout(() => {
        expect(errorMessage.style.display).toBe('block');
        expect(errorMessage.textContent).toBe('Login successful!');
        expect(errorMessage.style.color).toBe('green');
        done();
    }, 100);
});
