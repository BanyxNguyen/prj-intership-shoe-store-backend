// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$('.btn-status').click(async (event) => {
    event.preventDefault();
    const idItem = $(event.currentTarget).data('order-id');
    const Status = $(event.currentTarget).data('status');
    try {
        const result = await fetch(`/api/Order/ChangeStaus?OrderId=${idItem}&Status=${Status}`).then(x => x.json())
        if (result) {
            $('#' + idItem).html(Status);
            event.currentTarget.remove();
            if (Status === 'Complete' || Status === 'Cancel') {
                document.querySelector('*[aria-labelledby="' + idItem + '"]')?.remove();
            }
        }
    } catch {

    }


});