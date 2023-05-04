$(document).ready(function () {

    $("#form-submit").click(function (e) {



        debugger;
        var formdata =
        {
            Name: $("#name").val(),
            Email: $("#email").val(),
            Subject: $("#subject").val(),
            Message: $("#message").val()
        }
        e.preventDefault();
        $.ajax({
            url: "/Contact/ContactAdd",
            type: "post",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(formdata),

            success: function (response) {
                if (response.isSuccess) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Mesajınız Başarıyla iletildi Teşekkürler',
                        showConfirmButton: false,
                        timer: 1500

                    })


                }
                else
                {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Hata Bir şey yanlış gitti!',
                        footer: '<a href="">Lütfen Daha Sonra Tekrar Deneyin</a>'
                    })
                }

            },
            error: function (response) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href="">Why do I have this issue?</a>'
                })

            }

        });

    });

});