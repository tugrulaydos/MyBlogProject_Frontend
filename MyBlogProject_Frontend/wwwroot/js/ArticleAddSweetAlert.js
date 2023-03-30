
$(document).ready(function () {
    $("#ArticleAdd").click(function (e) {

        debugger;

        var formData = new FormData();

        var file = $("#customFile").get(0).files[0];

        formData.append("Title", $('#ArticleName').val());
        formData.append("Content", $("#defaultFormControlInput").val());
        formData.append("CategoryId", $("#CategoryID").val());
        formData.append("ArticlePhoto", file);



        e.preventDefault();


        let timerInterval
        Swal.fire({
            title: 'Lütfen Bekleyiniz!',

            width: 600,
            padding: '3em',
            color: '#716add',


            html: ' <b></b> milisaniye',
            timer: 1500,
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading()
                const b = Swal.getHtmlContainer().querySelector('b')
                timerInterval = setInterval(() => {
                    b.textContent = Swal.getTimerLeft()
                }, 100)
            },
            willClose: () => {
                clearInterval(timerInterval)
            }
        }).then((result) => {

            if (result.dismiss === Swal.DismissReason.timer) {

                $.ajax({

                    url: "/Article/Add",
                    method: "Post",
                    dataType: 'json',
                    data: formData,

                    contentType: false,
                    processData: false,
                    success: function (data) {
                        if (data.isSuccess) {
                            Swal.fire({
                                position: 'top-end',
                                icon: 'success',
                                title: 'Your work has been saved',
                                showConfirmButton: false,
                                timer: 1500
                            },
                                setTimeout(function () {
                                    window.location.href = "/Article/Index"

                                }, 1500)
                            )
                        }
                        else {

                            swal.fire(
                                'Error!',
                                'Your file has not been added',
                                'error'
                            )

                        }
                    },
                    error: function () {

                    }
                });

            }


        });

    });

});








