$(function () {
    var langs = ["Freehold", "Leasehold", "Share of Freehold"];
    $('#lang').autocomplete({
        source: langs
    });
});
//$(function () {
//    $("[data-autocomplete-source]").each(function () {
//        var target = $(this);
//        target.autocomplete({ source: target.attr("data-autocomplete-source") });
//    });
//});

