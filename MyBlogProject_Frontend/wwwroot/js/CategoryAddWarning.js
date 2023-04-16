$(document).ready(function () {
    $("#AddCategory").click(function (e) {

        var formdata =
        {

            Name: $("#CategoryName").val()

        }

        e.preventDefault();


        let timerInterval
        Swal.fire({
            title: 'Kategori Ekleniyor!',

            width: 600,
            padding: '3em',
            color: '#716add',
            background: '#fff url(/images/trees.png)',

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

                    url: "/admin/Category/Add",
                    type: "Post",
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify(formdata),

                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire({
                                position: 'top-end',
                                icon: 'success',
                                title: 'Kategori Başarıyla Eklendi.',
                                showConfirmButton: false,
                                timer: 1500
                            })
                            setTimeout(function () {
                                window.location.href = window.location.reload();

                            }, 1500)

                        }
                        else {

                            swal.fire({
                                icon: 'error',
                                title: 'Kategori Kaydedilemedi',
                                html:response.message                                

                            })

                        }
                    },
                    error: function () {

                    }
                });

            }


        });

    });

});








