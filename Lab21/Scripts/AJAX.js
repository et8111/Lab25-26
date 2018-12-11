$(document).ready(function () {
    $("#subButton").contextmenu(function () {
        var b = document.getElementsByTagName("input");
        $.ajax({
            type: 'GET',
            url: "autoFill",
            success: function (result) {
                for (var i = 0; i < 8; i++)
                    b[i].value = result[i];
                validate();
            }
        });
    });
});