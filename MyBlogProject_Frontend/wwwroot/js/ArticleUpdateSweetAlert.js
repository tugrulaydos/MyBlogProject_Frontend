

$(document).ready(function () {

    $("#UpdateButon").click(function (e) {

        var dataform =
        {
            ID: $("#ArticleID").val(),
            Title: $("#ArticleTitle").val(),
            Content: $("#ArticleContent").val(),
            CategoryId: $("#ArticleCategoryID").val()
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
                    url: "/Article/Update",
                    type: "post",
                    contentType: 'application/json',
                    datatype: "json",
                    data: JSON.stringify(dataform),

                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Güncelle!',
                                'Makale Başarıyla Güncellendi',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/Article/Index"
                            }, 1500)
                        }
                        else {
                            swal.fire({
                                icon: 'error',
                                title: 'Makale Güncellenemedi',
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