$(function () {
    var menu = $('#Menu');
   menu.on('mouseover', function () {
       $(this).child.slideDown(200);
   });
    $('.Content').display = NONE;
    menu.on('click', 'button', function() {
        preventDefault();
        $(this).css({ 'visibility': false });
    });
});