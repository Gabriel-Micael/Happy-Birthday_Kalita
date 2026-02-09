const confettiContainer = document.getElementById('confetti-container');
const balloonContainer = document.getElementById('balloon-container');

const balloonPalette = [
    '#ff4d6d',
    '#ffd166',
    '#06d6a0',
    '#4cc9f0',
    '#a78bfa',
    '#ff8fab'
];

const confettiPalette = [
    '#ff4d6d',
    '#ffd166',
    '#06d6a0',
    '#4cc9f0',
    '#8338ec',
    '#ffbe0b',
    '#fb5607',
    '#3a86ff'
];

function randomFrom(array) {
    return array[Math.floor(Math.random() * array.length)];
}

function releaseConfettiBurst(originX, originY, amount = 90) {
    if (!confettiContainer) return;

    for (let i = 0; i < amount; i++) {
        const confetti = document.createElement('span');
        confetti.className = 'burst-confetti';

        const angle = Math.random() * Math.PI * 2;
        const velocity = 120 + Math.random() * 260;
        const driftX = Math.cos(angle) * velocity;
        const driftY = Math.sin(angle) * velocity - (120 + Math.random() * 130);

        confetti.style.left = `${originX}px`;
        confetti.style.top = `${originY}px`;
        confetti.style.setProperty('--drift-x', `${driftX.toFixed(2)}px`);
        confetti.style.setProperty('--drift-y', `${driftY.toFixed(2)}px`);
        confetti.style.setProperty('--rotation', `${Math.random() * 720 - 360}deg`);
        confetti.style.setProperty('--duration', `${(1.6 + Math.random() * 1.7).toFixed(2)}s`);
        confetti.style.setProperty('--size', `${(5 + Math.random() * 9).toFixed(1)}px`);
        confetti.style.background = randomFrom(confettiPalette);
        confetti.style.borderRadius = Math.random() > 0.5 ? '2px' : '999px';

        confettiContainer.appendChild(confetti);
        setTimeout(() => confetti.remove(), 3600);
    }
}

function createBalloon(side, offsetIndex) {
    if (!balloonContainer) return;

    const balloon = document.createElement('button');
    balloon.type = 'button';
    balloon.className = `confetti-balloon confetti-balloon--${side}`;
    balloon.setAttribute('aria-label', 'Estourar balão de confete');

    const color = randomFrom(balloonPalette);
    const top = 10 + Math.random() * 18;
    const sideBase = 2 + offsetIndex * 8 + Math.random() * 4;

    balloon.style.background = `radial-gradient(circle at 35% 30%, rgba(255,255,255,0.95), ${color} 42%, color-mix(in srgb, ${color}, #000 22%) 100%)`;
    balloon.style.top = `${top}vh`;
    balloon.style[side] = `${sideBase}vw`;
    balloon.style.setProperty('--float-duration', `${(4.5 + Math.random() * 2.8).toFixed(2)}s`);
    balloon.style.setProperty('--float-delay', `${(-Math.random() * 3).toFixed(2)}s`);
    balloon.style.setProperty('--float-distance', `${(10 + Math.random() * 14).toFixed(1)}px`);
    balloon.style.setProperty('--tilt', `${(Math.random() * 6 - 3).toFixed(2)}deg`);

    balloon.addEventListener('click', () => {
        const rect = balloon.getBoundingClientRect();
        const x = rect.left + rect.width / 2;
        const y = rect.top + rect.height / 2;

        balloon.classList.add('is-popping');
        releaseConfettiBurst(x, y);

        setTimeout(() => {
            balloon.remove();
            createBalloon(side, offsetIndex);
        }, 240);
    });

    balloonContainer.appendChild(balloon);
}

if (balloonContainer) {
    const balloonsPerSide = window.innerWidth < 700 ? 2 : 3;
    for (let i = 0; i < balloonsPerSide; i++) {
        createBalloon('left', i);
        createBalloon('right', i);
    }
}

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
document.addEventListener('DOMContentLoaded', () => {
    const colors = [
        '#fff8b3',
        '#ffd1dc',
        '#b9fbc0',
        '#bde0fe',
        '#d8b4f8'
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
