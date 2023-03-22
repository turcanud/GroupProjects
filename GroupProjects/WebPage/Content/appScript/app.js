const toggleButton = document.getElementById('dark-mode-toggle');

// Check if dark mode is already enabled
if (localStorage.getItem('dark-theme-enabled') === 'true') {
     enableDarkMode();
}

toggleButton.addEventListener('click', function () {
     const body = document.body;
     body.classList.toggle('dark-theme');

     // Toggle the dark mode setting in local storage
     if (body.classList.contains('dark-theme')) {
          localStorage.setItem('dark-theme-enabled', 'true');
     } else {
          localStorage.setItem('dark-theme-enabled', 'false');
     }
});

function enableDarkMode() {
     const body = document.body;
     body.classList.add('dark-theme');
}

const mascotContainer = document.getElementById('mascot-container');
const mascotMessage = document.getElementById('mascot-message');
// Check if the mascot has already been shown
if (!localStorage.getItem('mascotShown')) {
     // Show the mascot for 3 seconds and then hide it gradually
     setTimeout(function () {
          mascotContainer.classList.add('hidden');
     }, 3000);

     // Show the mascot
     mascotContainer.style.visibility = 'visible';
     mascotMessage.style.visibility = 'visible';

     // Set the flag indicating that the mascot has been shown
     localStorage.setItem('mascotShown', true);
}
