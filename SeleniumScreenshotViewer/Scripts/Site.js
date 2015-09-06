$(document).ready(function () {
    console.log("click");
    $(".card").on("click", function () {
        var url = $(this).data("url");
        window.location = url;
    });

    $(".list").on("click", function () {
        var url = $(this).data("url");
        window.location = url;
    });

    //$(function () {
    //    var card = $('.card h2');
    //    var fontSize = parseInt(card.css('font-size'));
    //    if (card.width() > 200) {
    //        do {
    //            fontSize--;
    //            card.css('font-size', fontSize.toString() + 'px');
    //        } while (card.width() > 200);
    //    }
    //});
});
