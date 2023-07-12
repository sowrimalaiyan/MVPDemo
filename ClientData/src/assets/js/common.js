$(document).ready(function() {
    // SIDE BAR
    $(document).on('click', '.menubar', function(e) {
        $(".sidemenu").toggleClass("hide");
        $("body").toggleClass("sm-overflow-hidden");
        $(".sidemenu  a span").toggleClass("menu-title");
        $(".content").toggleClass("hide");
        if ($(".sidemenu").hasClass("hide")) {
            $(".mobile-sidebar-backdrop").addClass("backdrop-opened");
        } else {
            $(".mobile-sidebar-backdrop").removeClass("backdrop-opened");
        }
    });
    // DROPDOWN WITH SUBMENU
    // $(document).on('click', '.dropdown-submenu a.submenu-a', function(e) {
    $('.dropdown-submenu a.submenu-a').on("click", function(e) {
        console.log("event triggerd");
        $("ul").find('.show-submenu').removeClass('show-submenu');
        $(this).next('ul').toggleClass("show-submenu");
        e.stopPropagation();
        e.preventDefault();
    });
    $(document).on('click', 'body', function(e) {
        // $('body').on("click", function() {
        $("ul").find('.show-submenu').removeClass('show-submenu');
    });
});