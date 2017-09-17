$(document).ready(function () {
    $('#uploadImage').click(function (event) {
        event.preventDefault();
        var files = document.getElementById('uploadFile').files;

        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    data.append("file" + x, files[x]);
                }
            }
            $.ajax({
            type: "POST",
            url: '@Url.Action("Upload", "Home")',
            contentType: false,
            processData: false,
            data: data,
            success: function (result) {
                $('#img').append(result);
            },
            error: function (xhr, status, p3) {
                alert(xhr.responseText);
            }
        });
        }
        else{
            alert("������� �� ������������ �������� ������ HTML5!");
        }
    })
})