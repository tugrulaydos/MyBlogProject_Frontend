﻿
$(document).ready(function () {
    $("#ArticleAdd").click(function (e) {

        var formdata =
        {
            
            Title: $("#ArticleName").val(),
            Content: $("#defaultFormControlInput").val(),
            CategoryId: $("#CategoryID").val()
        }

        e.preventDefault();

      
        let timerInterval
        Swal.fire({
            title: 'Lütfen Bekleyiniz!',

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

                    url: "/Article/Add",
                    type: "Post",
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify(formdata),                    

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







