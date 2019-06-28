$(function () {
    $("#tblDepartmanlar").DataTable({
        "language": {
            "url":"//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });

    $("#tblPersoneller").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });

    $("#tblKullanicis").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });


    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı Silmek İstediğinizden Eminmisiniz ?", function(result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        })
    });
});