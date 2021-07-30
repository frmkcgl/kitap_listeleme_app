var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/kitap",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "kitapAd", "width": "20%" },
            { "data": "yazar", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/KitapListesi/GuncelleEkle?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width:85px;'>Guncelle</a>
                            &nbsp;
                            <a  class='btn btn-danger text-white' style='cursor:pointer;width:85px;' onclick=Delete('/api/kitap?id='+${data})>
                            Sil</a> </div>`;
                }, "width": "40%"
            }
        ],

        "language": {
            "emptyTable": "Veri Bulunamadı!"
        },

        "width": "100%"

    });
}

function Delete(url) {
    swal({
        title: "Silmek istediğinizden eminmisiniz?",
        text: "İlgili veri silinirse tekrar geri döndürülemeyecektir!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((silinecekmi) => {
        if (silinecekmi) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
