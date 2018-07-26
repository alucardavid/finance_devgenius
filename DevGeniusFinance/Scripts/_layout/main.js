
$(document).ready(function () {

    $('#sidebarCollapse').click(function () {
        $('#sidebar').toggleClass('active');
    });

    $('body').on('click touchstart', function (e) {
        if (!$(e.target).closest('#sidebar').length) {
            if (!$(e.target).hasClass('oi oi-menu')) {
                $('#sidebar').removeClass('active');
            }
        }
    });


});