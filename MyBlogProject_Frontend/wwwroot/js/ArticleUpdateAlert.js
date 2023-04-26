

$(document).ready(function () {

    $("#UpdateButon").click(function (e) {
        debugger;
        var formData = new FormData();

        var file = $("#updateFile").get(0).files[0];

        formData.append("ID", $("#ArticleID").val());
        formData.append("Title", $("#ArticleTitle").val());
        formData.append("Content", $("#ArticleContent").val());
        formData.append("CategoryId", $("#ArticleCategoryID").val());
        formData.append("ArticlePhoto", file);

        //var dataform =
        //{
        //    ID: $("#ArticleID").val(),
        //    Title: $("#ArticleTitle").val(),
        //    Content: $("#ArticleContent").val(),
        //    CategoryId: $("#ArticleCategoryID").val()
        //}

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
                    url: "/Admin/Article/Update",
                    method: "post",                    
                    dataType: 'json',
                    data: formData,
                    contentType: false,
                    processData:false,

                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Güncelle!',
                                'Makale Başarıyla Güncellendi',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/Admin/Article/Index"
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