﻿
$(document).ready(function () {
    $(".DeleteCategory").click(function (e) {

        const dataId = $(this).attr("y");

        e.preventDefault();

        Swal.fire({
            title: 'Emin Misiniz?',
            text: "Bu işlemi Geri Alamazsınız!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Sil!',
            cancelButtonText: "İptal",
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/admin/Category/HardDelete",
                    type: "Post",
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify(dataId),
                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Deleted!',
                                'Makale Başarıyla Silindi.',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/admin/Category/DeletedCategory"

                            }, 1500)
                        }
                        else {
                            Swal.fire(
                                'Deleted!',
                                'Makale Silinirken Bir Hata Oluştu!',
                                'error'
                            )
                        }

                    },
                    error: function (response) {


                    }
                });

            }
        });


    });

});