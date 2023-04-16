

$(document).ready(function () {

    $("#CategoryUpdate").click(function (e) {

        var dataform =
        {
            ID: $("#CategoryID").val(),
            Name: $("#CategoryName").val()
        }

        e.preventDefault();

        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu işlemi geri alamassınız!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Güncelle!',
            cancelButtonText: "İptal"
        }).then((result) => {

            if (result.isConfirmed) {

                $.ajax({
                    url: "/admin/Category/CategoryUpdate",
                    type: "post",
                    contentType: 'application/json',
                    datatype: "json",
                    data: JSON.stringify(dataform),

                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Güncelle!',
                                'Kategori Başarıyla Güncellendi',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/admin/Category/Index"
                            }, 1500)
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Kategori Güncellenemedi',
                                html: response.message

                            })
                        }

                    },
                    error: function (response) {

                    }

                });
            }
        });


    });

});