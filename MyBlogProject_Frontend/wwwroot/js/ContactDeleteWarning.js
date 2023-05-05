$(document).ready(function () {
    $(".ContactDeleteButon").click(function (e) {


        const dataId = $(this).attr("x");

        e.preventDefault();

        Swal.fire({
            title: 'Emin Misiniz?',
            text: 'Bu işlemi Geri Alamassınız',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Sil!',
            cancelButtonText: 'İptal',
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/admin/MessageBox/Delete",
                    type: "Post",
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify(dataId),
                    success: function (response)
                    {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Deleted!',
                                'Mesaj Başarıyla Silindi',
                                'success'
                            )
                            setTimeout(function () {
                                window.location.href = "/admin/MessageBox/Index"

                            }, 1500)

                        }
                        else
                        {
                            Swal.fire(
                                'Deleted!',
                                'Mesaj Silinirken Bir Hata Oluştu!',
                                'error'
                            )
                        } 

                    }
                });
            }
            else
            {
                Swal.fire(
                    'Deleted!',
                    'Mesaj Silinirken Bir Hata Oluştu!',
                    'error'
                )
            }
        });
    });

});