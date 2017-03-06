$("document").ready(function () {
    $(".buy-button").click(function () {
        var cantidad = $('.cuantity', $(this).closest('.row')).val();
        $(this).attr('href', $(this).attr('href') + cantidad);
    });
});