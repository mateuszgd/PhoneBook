$(function () {
    $(".details").click(function () {
        debugger;
        var $link = $(this);
        var id_modal = $link.attr('data-id');
        $.ajax({
            type: "GET",
            url: "/People/Details",
            contentType: "application/json; charset=utf-8",
            data: { "Name": id_modal },
            datatype: "json",
            success: function (e) {
                debugger;
                $('#myModalHtml').html(e);
                $('#myModal').modal('show');
                $('#myModal').modal({ keyboard: false });
            }
        });
    });
    $("#close").click(function () {
        $('#myModal').modal('hide');
    });
});