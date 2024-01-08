import { HandleTheErrors } from "../HandleTheErrors.js";
$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var productId = button.data('id') // Extract info from data-* attributes

    $.ajax({
        url: '/Product/GetById',
        type: 'GET',
        data: { id: productId },
        success: function (response) {
            $('#productId').val(response.id);
            $('#strongName').html(response.name);
        },
        error: function (response) {
            console.log("Hata :", response);
        }
    });

});


$('#deleteForm').submit(function (e) {
    var table = $('#table');

    var productId = $('#productId').val();

    $.ajax({
        url: '/Product/Delete',
        type: 'DELETE',
        data: { id: productId },
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                $('#deleteModal').modal('hide');
                $('#table').DataTable().ajax.reload();
            }
        },
        error: function (response) {
            console.log("Hata :", response);
        }
    });

    e.preventDefault();

});