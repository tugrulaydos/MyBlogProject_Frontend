
$(document).ready(function () {    
    $("#DeleteArticle").click(function (e) {   
               
        const dataId = $("#DeleteArticle").attr("span");       
        e.preventDefault();        
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {           
                    $.ajax({
                        url: "/Article/Delete",
                        type: "Post",
                        contentType: 'application/json',
                        dataType: 'json',
                        data: JSON.stringify(dataId),
                        success: function (response) {          
                            if (response.isSuccess) {
                                Swal.fire(
                                    'Deleted!',
                                    'Your file has been deleted.',
                                    'success'
                                )
                                setTimeout(function () {
                                    window.location.href = "/Article/Index"

                                }, 1500)
                            }
                            else {
                                Swal.fire(
                                    'Deleted!',
                                    'Your file has not been deleted.',
                                    'error'
                                )
                            }

                        },
                        error: function (response) {
                            

                        }
                    });            

            }
        });                       

    });

});

