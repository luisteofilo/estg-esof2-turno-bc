(function($) {
    "use strict";

    var fullHeight = function() {
        $('.js-fullheight').css('height', $(window).height());
        $(window).resize(function(){
            $('.js-fullheight').css('height', $(window).height());
        });
    };
    fullHeight();

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });
})(jQuery);

document.addEventListener('DOMContentLoaded', function () {
    const sidebarCollapseButton = document.getElementById('sidebarCollapse');
    const sidebar = document.getElementById('sidebar');

    if (sidebarCollapseButton && sidebar) {
        sidebarCollapseButton.addEventListener('click', function () {
            sidebar.classList.toggle('collapsed');
        });
    }
});