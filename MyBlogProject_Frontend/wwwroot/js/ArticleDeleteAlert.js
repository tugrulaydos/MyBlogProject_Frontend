
$(document).ready(function () {
    $(".DeleteArticle").click(function (e) {


        const dataId = $(this).attr("span");

        e.preventDefault();

        Swal.fire({
            title: 'Emin Misiniz?',
            text: "Gerçekten Silmek İstiyor musunuz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Sil!',
            cancelButtonText: "İptal",
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/admin/Article/Delete",
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
                                window.location.href = "/admin/Article/Index"

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
