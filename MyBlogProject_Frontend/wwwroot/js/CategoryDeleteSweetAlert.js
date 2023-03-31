
$(document).ready(function () {

    $(".DeleteCategory").click(function (e) {


        const dataId = $(this).attr("span");
        e.preventDefault();

        Swal.fire({
            title: 'Emin Misiniz?',
            text: "Bu İşlemi Geri Alamassınız!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Sil!',
            cancelButtonText:"İptal",
        }).then((result) => {
            if (result.isConfirmed) {

                $.ajax({
                    url: "/Category/Delete",
                    type: "Post",
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify(dataId),
                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Deleted!',
                                'Kategori Başarıyla Silindi',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/Category/Index"

                            }, 1500)
                        }
                        else {
                            swal.fire(
                                'Deleted!',
                                'Kategori Silinirken Bir Hata Oluştu!',
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

