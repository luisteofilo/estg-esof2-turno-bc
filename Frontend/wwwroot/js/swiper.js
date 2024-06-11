
function sayHi(str) {
    console.log("Hi" + str)
}

function handleButtonClick(action) {
    const swiper = document.getElementById("swiper");
    const cards = swiper.getElementsByClassName("card");

    if (cards.length > 0) {
        let card = cards[0];
        card.style.transition = "transform 0.5s, opacity 0.5s";
        const wineName = card.getAttribute('data-wine-name');
        const wineTipo = card.getAttribute('data-wine-tipo');

        switch (action) {
            case "dislike":
                card.style.transform = "translateX(-430px) translateY(80px) scale(0.3)";
                break;
            case "superLike":
                card.style.transform = "translateY(300px) scale(0.3)";
                console.log("Hi");
                break;
            case "like":
                card.style.transform = "translateX(430px) translateY(80px) scale(0.3)";
                console.log("Hi");
                break;
        }

        card.style.opacity = "0";
        setTimeout(() => {
            card.remove();
            updateCardPositions();
        }, 500);
    }
}

function updateCardPositions() {
    const swiper = document.getElementById("swiper");
    const cards = swiper.getElementsByClassName("card");
    for (let i = 0; i < cards.length; i++) {
        cards[i].style.transition = "none";
        cards[i].style.transform = `translateZ(calc(-20px * ${i})) translateY(calc(-5px * ${i})) rotate(calc(-3deg * ${i}))`;
        cards[i].style.opacity = "1";
    }
}