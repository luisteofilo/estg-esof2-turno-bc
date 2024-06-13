function handleButtonClick(action) {
    const swiper = document.getElementById("swiper");
    const cards = swiper.getElementsByClassName("card");

    if (cards.length > 0) {
        let card = cards[0];
        const vinho_id = card.getAttribute('data-wine-id');

        const interaction = {
            user_id: getUserId(),
            vinho_id: vinho_id,
            tipo_interacao: 0
        };
        
        card.style.transition = "transform 0.5s, opacity 0.5s";

        switch (action) {
            case "dislike":
                card.style.transform = "translateX(-130px) translateY(300px) scale(0.3)";
                interaction.tipo_interacao = 0;
                break;
            case "superLike":
                card.style.transform = "translateY(300px) scale(0.3)";
                interaction.tipo_interacao = 2;
                break;
            case "like":
                card.style.transform = "translateX(130px) translateY(300px) scale(0.3)";
                interaction.tipo_interacao = 1;
                break;
        }

        card.style.opacity = "0";
        setTimeout(() => {
            card.remove();
            updateCardPositions();
        }, 500);
        
        sendInteraction(interaction)
            .then(() => {
                console.log("Interaction sent successfully");
            })
            .catch((error) => {
                console.error("Failed to send interaction", error);
            });
    }
}

function getUserId() {
    return  sessionStorage.getItem('selectedUserId');
}

async function sendInteraction(interaction) {
    const response = await fetch("http://localhost:5295/create-interaction", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(interaction)
    });
    if (!response.ok) {
        console.error("Failed to send interaction");
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
