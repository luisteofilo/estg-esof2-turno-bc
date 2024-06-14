function handleButtonClick(action) {
    const userId = getUserId();
    if (!userId) {
        showWarning('User must be logged in. Please select one!');
        return;
    }
    
    const swiper = document.getElementById("swiper");
    const cards = swiper.getElementsByClassName("card");

    if (cards.length > 0) {
        let card = cards[0];
        const vinhoId = card.getAttribute('data-wine-id');

        const interaction = {
            user_id: userId,
            vinho_id: vinhoId,
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
        

        checkInteractionExists(interaction)
            .then(exists => {
                if (exists === 0) {
                    createInteraction(interaction)
                        .then(() => {
                            console.log("Interaction sent successfully");
                        })
                        .catch((error) => {
                            console.error("Failed to send interaction", error);
                        });
                } else if (exists === 1) {
                    updateInteraction(interaction)
                        .then(() => {
                            console.log("Interaction updated successfully");
                        })
                        .catch((error) => {
                            console.error("Failed to update interaction", error);
                        });
                }
            })
            .catch((error) => {
                console.error("Failed to check interaction existence", error);
            });
    }
}

function getUserId() {
    return sessionStorage.getItem('selectedUserId');
}

function showWarning(message) {
    const warningDiv = document.getElementById('warning-message');
    const warningText = document.getElementById('warning-text');

    warningText.innerText = message;
    warningDiv.style.display = 'block';
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

async function checkInteractionExists(interaction) {
    const response = await fetch(`https://localhost:7103/get-interaction?user_id=${interaction.user_id}&vinho_id=${interaction.vinho_id}`);
    if (!response.ok) {
        throw new Error("Failed to check interaction existence");
    }
    return await response.json();
}

async function createInteraction(interaction) {
    const response = await fetch(`https://localhost:7103/create-interaction`, {
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

async function updateInteraction(interaction, apiUrl) {
    const response = await fetch(`https://localhost:7103/update-interaction`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(interaction)
    });

    if (!response.ok) {
        console.error("Failed to update interaction");
    } else {
        console.log("Interaction updated successfully");
    }
}
