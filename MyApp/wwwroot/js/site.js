const container = document.getElementById("confetti-container");

function createConfetti() {
    if (!container) return;

    const confetti = document.createElement("div");
    confetti.classList.add("confetti");

    confetti.style.left = Math.random() * 100 + "vw";
    confetti.style.backgroundColor = `hsl(${Math.random() * 360}, 100%, 70%)`;
    confetti.style.animationDuration = (Math.random() * 3 + 2) + "s";
    confetti.style.width = confetti.style.height = Math.random() * 8 + 5 + "px";

    container.appendChild(confetti);

    setTimeout(() => confetti.remove(), 4000);
}

setInterval(createConfetti, 120);

/* carrossel */
const slides = document.querySelectorAll('.carousel-item');
const indicators = document.querySelectorAll('.indicator');
const total = slides.length;
let index = 0;
const carousel = document.querySelector('.carousel');
const nextButton = document.querySelector('.next');
const prevButton = document.querySelector('.prev');

if (carousel && total > 0 && indicators.length === total && nextButton && prevButton) {
    /* --- Função para ajustar altura do carrossel --- */
    function adjustCarouselHeight() {
        const active = document.querySelector('.carousel-item.active');
        if (!active) return;

        const imgs = active.querySelectorAll('img');
        const waitImages = Array.from(imgs).map(img => {
            if (img.complete) return Promise.resolve();
            return new Promise(res => {
                img.addEventListener('load', res, { once: true });
                img.addEventListener('error', res, { once: true });
            });
        });

        Promise.all(waitImages).then(() => {
            const height = active.offsetHeight;
            carousel.style.height = height + 'px';
        });
    }

    const showSlide = (i) => {
        slides.forEach((slide, j) => {
            const shouldActivate = j === i;
            slide.classList.toggle('active', shouldActivate);
            indicators[j].classList.toggle('active', shouldActivate);
        });

        requestAnimationFrame(adjustCarouselHeight);
    };

    const nextSlide = () => {
        index = (index + 1) % total;
        showSlide(index);
    };

    const prevSlide = () => {
        index = (index - 1 + total) % total;
        showSlide(index);
    };

    nextButton.addEventListener('click', () => {
        nextSlide();
    });

    prevButton.addEventListener('click', () => {
        prevSlide();
    });

    indicators.forEach((dot, i) => {
        dot.addEventListener('click', () => {
            index = i;
            showSlide(index);
        });
    });

    let startX = 0;
    let endX = 0;
    const threshold = 50;

    carousel.addEventListener('touchstart', (e) => {
        startX = e.touches[0].clientX;
        endX = startX;
    });

    carousel.addEventListener('touchmove', (e) => {
        endX = e.touches[0].clientX;
    });

    carousel.addEventListener('touchend', () => {
        const diff = startX - endX;
        if (Math.abs(diff) > threshold) {
            if (diff > 0) {
                nextSlide();
            } else {
                prevSlide();
            }
        }
    });

    window.addEventListener('load', () => {
        showSlide(index);
    });

    window.addEventListener('resize', () => {
        adjustCarouselHeight();
    });
}


//post-it
document.addEventListener("DOMContentLoaded", () => {
    const colors = [
        "#fff8b3",
        "#ffd1dc",
        "#b9fbc0",
        "#bde0fe",
        "#d8b4f8"
    ];

    document.querySelectorAll('.postit').forEach(el => {
        const randomColor = colors[Math.floor(Math.random() * colors.length)];
        const randomRotation = (Math.random() * 16 - 8).toFixed(1) + 'deg';

        el.style.setProperty('--postit-color', randomColor);
        el.style.setProperty('--rotation', randomRotation);
    });
});

window.addEventListener('scroll', () => {
    const posts = document.querySelectorAll('.postit');
    const screenCenter = window.innerHeight / 2;

    posts.forEach(post => {
        const rect = post.getBoundingClientRect();
        const postCenter = rect.top + rect.height / 2;
        const tolerance = 150;

        if (Math.abs(postCenter - screenCenter) < tolerance) {
            post.classList.add('active');
        } else {
            post.classList.remove('active');
        }
    });
});
