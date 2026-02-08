const container = document.getElementById("confetti-container");

function createConfetti() {
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
const mobileBreakpoint = 600;
let isMobileMode = false;

/* --- Função para ajustar altura do carrossel --- */
function adjustCarouselHeight() {
    if (isMobileMode) {
        carousel.style.height = 'auto';
        return;
    }

    const active = document.querySelector('.carousel-item.active');
    if (!active) return;

    // Aguarda imagens carregarem antes de medir
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
        carousel.style.height = height + 'px'; // aplica altura em px p/ permitir animação
    });
}

/* --- Exibe slide e ajusta altura --- */
const showSlide = (i) => {
    slides.forEach((slide, j) => {
        const shouldActivate = j === i;
        slide.classList.toggle('active', shouldActivate);
        indicators[j].classList.toggle('active', j === i);
    });

    // ajusta altura suavemente
    requestAnimationFrame(() => adjustCarouselHeight());
};

const updateCarouselMode = () => {
    const shouldUseMobileMode = window.innerWidth <= mobileBreakpoint;

    if (shouldUseMobileMode === isMobileMode) return;

    isMobileMode = shouldUseMobileMode;
    carousel.classList.remove('mobile-scroll');

    showSlide(index);
};

/* --- Controles --- */
const nextSlide = () => {
    index = (index + 1) % total;
    showSlide(index);
};

const prevSlide = () => {
    index = (index - 1 + total) % total;
    showSlide(index);
};

/* --- Botões --- */
nextButton.addEventListener('click', () => {
    nextSlide();
});

prevButton.addEventListener('click', () => {
    prevSlide();
});

/* --- Indicadores --- */
indicators.forEach((dot, i) => {
    dot.addEventListener('click', () => {
        index = i;
        showSlide(index);
    });
});

/* --- Suporte a swipe (toque) no celular --- */
let startX = 0;
let endX = 0;
const threshold = 50;

carousel.addEventListener('touchstart', (e) => {
    startX = e.touches[0].clientX;
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


/* --- Ajusta altura inicial e em redimensionamentos --- */
window.addEventListener('load', () => {
    updateCarouselMode();
    showSlide(index); // força ajuste inicial
});
window.addEventListener('resize', () => {
    updateCarouselMode();
    adjustCarouselHeight();
});


//post-it
document.addEventListener("DOMContentLoaded", () => {
    const colors = [
        "#fff8b3", // amarelo
        "#ffd1dc", // rosa
        "#b9fbc0", // verde claro
        "#bde0fe", // azul bebê
        "#d8b4f8"  // roxo pastel
    ];

    document.querySelectorAll('.postit').forEach(el => {
        const randomColor = colors[Math.floor(Math.random() * colors.length)];
        const randomRotation = (Math.random() * 16 - 8).toFixed(1) + 'deg';

        el.style.setProperty('--postit-color', randomColor);
        el.style.setProperty('--rotation', randomRotation);
    });
});

//detecta scrow
window.addEventListener('scroll', () => {
    const posts = document.querySelectorAll('.postit');
    const screenCenter = window.innerHeight / 2;

    posts.forEach(post => {
        const rect = post.getBoundingClientRect();
        const postCenter = rect.top + rect.height / 2;

        // margem de tolerância (quanto "próximo" do centro conta como ativo)
        const tolerance = 150;

        if (Math.abs(postCenter - screenCenter) < tolerance) {
            post.classList.add('active');
        } else {
            post.classList.remove('active');
        }
    });
});
