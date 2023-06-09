﻿


$(document).ready(function () {


    $("#btnSave").click(function (event) {

        

        event.preventDefault();

        var addUrl = app.Urls.categoryAddUrl;
        var redirectUrl = app.Urls.articleAddUrl;

        var categoryAddDto = {
            Name: $("input[id=categoryName]").val()
        }

        var jsonData = JSON.stringify(categoryAddDto);    



        $.ajax({
            url: addUrl,
            type: "Post",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
           

                success: function (response) {
                    if (response.isSuccess) {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Kategori Başarıyla Eklendi',
                            showConfirmButton: false,
                            timer: 2000
                        })
                        setTimeout(function () {
                            window.location.href = redirectUrl;
                        }, 1700)
                    }
                    else {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'error',
                            title: 'Kategori Eklenirken Bir Hata Oluştu',
                            html: response.message,
                            showConfirmButton: false,
                            timer: 3000
                        })
                    }

                },
                error: function (response) {

                }
        

        });

    });

});