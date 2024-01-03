import { HandleTheErrors } from "../HandleTheErrors.js";

$('#editModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var categoryId = button.data('id') // Extract info from data-* attributes

    $.ajax({
        url: "/Category/CategoryGetById",
        data: { id: categoryId },
        type: "GET",
        success: function (response) {
            $('#editName').val(response.name);
            $('#categoryId').val(response.id);
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

});

$('#editForm').submit(function (e) {

    var data = {
        Id: $('#categoryId').val(),
        Name: $('#editName').val(),
    };

    $.ajax({
        url: "/Category/CategoryEdit",
        data: data,
        type: "POST",
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                $('#editModal').modal('hide');
                $('#table').DataTable().ajax.reload();
            }
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

    e.preventDefault();
});