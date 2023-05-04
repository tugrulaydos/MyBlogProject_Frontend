$(document).ready(function () {
   
    $("#form-submit").click(function (e) {
        e.preventDefault();
        alert("Merhaba");
        debugger;
        var formdata =
        {
            Name: $("#name").val(),
            Email: $("#email").val(),
            Subject: $("#subject").val(),
            Message: $("#message").val()
        }

        $.ajax({
            url: "/Contact/ContactAdd",
            type: "Post",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(formdata)
            

           

        });
       
           

    });

});