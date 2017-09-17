$('#foo').change(function() {
    var page = $('select[name="page"]').val();
    $.ajax({
        method: "POST",
        url: "/Home/Index/",
        data: { pageNumber: 1, pageSize: page }
    })
    .success(function (html) {
        $("#ddd").empty().append(html);
    });
});