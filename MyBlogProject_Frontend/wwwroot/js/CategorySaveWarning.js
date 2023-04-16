
$(document).ready(function () {
    $(".SavedCategory").click(function (e) {

        const Id = $(this).attr("x");
        debugger;
        e.preventDefault();
        Swal.fire({
            title: 'Emin Misin?',
            text: "Kategoriyi Kurtarmak istiyor musun?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Kurtar',
            cancelButtonText: "İptal"
        }).then((result) => {
            if (result.isConfirmed) {

                $.ajax({

                    url: "/admin/Category/Save",
                    type: "Post",
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify(Id),

                    success: function (response) {
                        if (response.isSuccess) {
                            swal.fire(
                                'Başarılı',
                                'Kategori Kurtarma işlemi Başarıyla Yapıldı',
                                'success'
                            ),
                                setTimeout(function () {
                                    window.location.href = "/admin/Category/DeletedCategory"

                                }, 1500)

                        }
                        else {

                            swal.fire(
                                'Hata!',
                                'Kurtarma İşlemi Yapılırken Hata Oluştu',
                                'error'
                            )

                        }
                    },
                    error: function () {

                    }
                });


            }
        })




    });

});

