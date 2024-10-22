window.addEventListener('scroll', () => {
    const roadmapItems = document.querySelectorAll('.roadmap-item');
    roadmapItems.forEach(item => {
        const rect = item.getBoundingClientRect();
        if (rect.top < window.innerHeight - 100) {
            item.classList.add('active');
        }
    });
});

// Show or hide the scroll indicator
let hasScrolled = false; // Variable para rastrear si se ha hecho scroll

window.addEventListener('scroll', function() {
    const scrollIndicator = document.getElementById('scrollIndicator');
    
    if (window.scrollY > 0 && !hasScrolled) {
        scrollIndicator.style.display = 'none';
        hasScrolled = true;
    }
});
