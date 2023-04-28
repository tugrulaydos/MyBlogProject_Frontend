

$(document).ready(function () {

    $("#UpdateButon").click(function (e) {

        debugger;
        
        var formData = new FormData();

        var file = $("#updateFile").get(0).files[0];

        formData.append("ID", $("#AboutID").val());
        
        formData.append("Content", $("#AboutContent").val());
        
        formData.append("AboutPhoto", file);

        

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
                    url: "/Admin/About/Update",
                    method: "post",
                    dataType: 'json',
                    data: formData,
                    contentType: false,
                    processData: false,

                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Güncelle!',
                                'İçerik Başarıyla Güncellendi',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/Admin/About/Index"
                            }, 1500)
                        }
                        else {
                            swal.fire({
                                icon: 'error',
                                title: 'İçerik Güncellenemedi',
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