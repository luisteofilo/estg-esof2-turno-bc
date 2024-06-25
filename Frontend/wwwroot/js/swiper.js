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
        const wineId = card.getAttribute('data-wine-id');

        const interaction = {
            UserId: userId,
            WineId: wineId,
            InteractionType: 0
        };

        card.style.transition = "transform 0.5s, opacity 0.5s";

        switch (action) {
            case "dislike":
                card.style.transform = "translateX(-130px) translateY(300px) scale(0.3)";
                interaction.InteractionType = 0;
                break;
            case "superLike":
                card.style.transform = "translateY(300px) scale(0.3)";
                interaction.InteractionType = 2;
                break;
            case "like":
                card.style.transform = "translateX(130px) translateY(300px) scale(0.3)";
                interaction.InteractionType = 1;
                break;
        }

        card.style.opacity = "0";
        setTimeout(() => {
            card.remove();
            updateCardPositions();
        }, 500);
        

        checkInteractionExists(interaction)
            .then(exists => {
                if (exists.interactionLinkId === "00000000-0000-0000-0000-000000000000"){
                    createInteraction(interaction)
                        .then(() => {
                            console.log("Interaction sent successfully");
                        })
                        .catch((error) => {
                            console.error("Failed to send interaction", error);
                        });
                } else {
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
    const response = await fetch(`https://localhost:7103/api/Interaction/show?userId=${interaction.UserId}&wineId=${interaction.WineId}`);
    
    return await response.json();
}

async function createInteraction(interaction) {
    const response = await fetch(`https://localhost:7103/api/Interaction/store`, {
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

async function updateInteraction(interaction) {
    const response = await fetch(`https://localhost:7103/api/Interaction/update?userId=${interaction.UserId}&wineId=${interaction.WineId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(interaction)
    });

    if (!response.ok) {
        console.error("Failed to update interaction");
    }
}
