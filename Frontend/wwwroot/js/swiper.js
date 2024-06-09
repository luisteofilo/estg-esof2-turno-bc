document.addEventListener('DOMContentLoaded', function () {
    let startPoint = null;
    let offsetX = 0;
    let offsetY = 0;
    let activeCard = null;
    let isDismissAnimationInProgress = false;
    const container = document.getElementById('borders');
    const boundaries = container.getBoundingClientRect();

    const handleMouseMovement = (event) => {
        if (!startPoint || !activeCard) return;
        if (isDismissAnimationInProgress) return;

        const mouseX = event.clientX;
        const mouseY = event.clientY;

        offsetX = mouseX - startPoint.x;
        offsetY = mouseY - startPoint.y;
        const rotate = offsetX * 0.1;

        activeCard.style.transform = `translate(${offsetX}px, ${offsetY}px) rotate(${rotate}deg)`;

        if (Math.abs(offsetX) > boundaries.width * 0.3 || Math.abs(offsetY) > boundaries.height * 0.3) {
            dismiss();
        }
    };

    const handleMouseUp = () => {
        if (activeCard) {
            startPoint = null;
            document.removeEventListener('mousemove', handleMouseMovement);

            activeCard.style.transition = 'transform 0.5s ease';
            activeCard.style.transform = 'translate(0, 0) rotate(0)';
        }
    };

    const mouseEventListener = (card) => {
        card.addEventListener('mousedown', (event) => {
            if (isDismissAnimationInProgress) return;
            event.preventDefault();

            startPoint = { x: event.clientX, y: event.clientY };
            activeCard = card;
            document.addEventListener('mousemove', handleMouseMovement);

            activeCard.style.transition = 'none';
        });

        document.addEventListener('mouseup', handleMouseUp);
    };

    const dismiss = () => {
        if (isDismissAnimationInProgress) return;

        isDismissAnimationInProgress = true;
        startPoint = null;
        document.removeEventListener('mouseup', handleMouseUp);
        document.removeEventListener('mousemove', handleMouseMovement);
        activeCard.remove();
        isDismissAnimationInProgress = false;

        activeCard = document.querySelector('.card');
        if (activeCard) {
            activeCard.style.transition = 'none';
            mouseEventListener(activeCard);
        }
    };
    
    const firstCard = document.querySelector('.card');
    mouseEventListener(firstCard);
});
