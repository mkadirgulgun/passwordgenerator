const lengthSlider = document.getElementById('length');
const lengthValue = document.getElementById('lengthValue');
const generateButton = document.getElementById('generate');
const passwordInput = document.getElementById('password');
const copyButton = document.getElementById('copy'); // Kopyalama butonu
const notification = document.getElementById('notification'); // Bildirim mesajı

lengthSlider.addEventListener('input', function() {
    lengthValue.textContent = this.value;
});

generateButton.addEventListener('click', function() {
    const length = lengthSlider.value;
    const includeUppercase = document.getElementById('uppercase').checked;
    const includeLowercase = document.getElementById('lowercase').checked;
    const includeNumbers = document.getElementById('numbers').checked;
    const includeSymbols = document.getElementById('symbols').checked;

    passwordInput.value = generatePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSymbols);
    showNotification("Şifre başarıyla oluşturuldu!"); // Bildirim göster
});

copyButton.addEventListener('click', function() {
    passwordInput.select();
    document.execCommand('copy'); // Şifreyi kopyala
    showNotification("Şifre kopyalandı!"); // Kopyalama bildirimini göster
});

function generatePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSymbols) {
    const uppercaseChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const lowercaseChars = 'abcdefghijklmnopqrstuvwxyz';
    const numberChars = '0123456789';
    const symbolChars = '!#$%^&*()_+[]{}|;:,.<>?';

    let charSet = '';
    if (includeUppercase) charSet += uppercaseChars;
    if (includeLowercase) charSet += lowercaseChars;
    if (includeNumbers) charSet += numberChars;
    if (includeSymbols) charSet += symbolChars;

    if (charSet.length === 0) return '';

    let password = '';
    for (let i = 0; i < length; i++) {
        const randomIndex = Math.floor(Math.random() * charSet.length);
        password += charSet[randomIndex];
    }

    return password;
}

function showNotification(message) {
    notification.textContent = message; // Mesajı göster
    notification.style.display = 'block'; // Bildirimi görünür yap
    setTimeout(() => {
        notification.style.display = 'none'; // 3 saniye sonra bildirimi gizle
    }, 3000);
}