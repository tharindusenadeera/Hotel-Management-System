$(document).ready(function () {
    $("#myNav").affix({
        offset: {
            top: $(".header").outerHeight(true)  /* Set top offset equal to header outer height including margin */
        }
    });
});