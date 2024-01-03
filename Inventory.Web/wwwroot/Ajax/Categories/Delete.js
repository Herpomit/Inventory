import { HandleTheErrors } from "../HandleTheErrors.js";

$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var categoryId = button.data('id') // Extract info from data-* attributes
    $.ajax({
        url: "/Category/CategoryGetById",
        data: { id: categoryId },
        type: "GET",
        success: function (response) {
            $('#strongName').text(response.name);
            $('#categoryId').val(response.id);
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

});


$('#deleteForm').submit(function (e) {
    var data = {
        Id: $('#categoryId').val(),
        Name: $('#strongName').val(),
    }

    $.ajax({
        url: "/Category/CategoryDelete",
        data: data,
        type: "DELETE",
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                $('#deleteModal').modal('hide');
                $('#table').DataTable().ajax.reload();
            }
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

    e.preventDefault();
});