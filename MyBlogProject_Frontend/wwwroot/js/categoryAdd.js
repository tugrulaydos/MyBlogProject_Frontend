//$(document).ready(function () {
//    $("@btnSave").click(function (event))
//    {
//        event.preventDefault();

//        var addUrl = app.Urls.categoryAddUrl;

//        var redirectUrl = app.Urls.articleAddUrl;

//        var categoryAddDto = {
//            Name: $("input[id=categoryName]").val()
//        }

//        var jsonData = JSON.stringify(categoryAddDto);

//        $.ajax({

//            url: addUrl,
//            type="Post",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            data: jsonData,

//            success: function (data)
//            {
//                setTimeout(function (data) {
//                    window.location.href = redirectUrl;

//                }, 1500);

//            },
//            error: function () {

//            }



//        });
//    });
//});


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
            


            success: function (data) {
                
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {
                toast.error("Bir hata oluştu.", "Hata");
            }

        });

    });

});