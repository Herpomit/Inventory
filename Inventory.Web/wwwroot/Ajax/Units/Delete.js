import { HandleTheErrors } from "../HandleTheErrors.js";


$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var unitId = button.data('id') // Extract info from data-* attributes

    $.ajax({
        url: "/Unit/UnitGetById",
        data: { id: unitId },
        type: "GET",
        success: function (response) {
            $('#strongName').text(response.name);
            $('#unitId').val(response.id);
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

});

$('#deleteForm').submit(function (e) {

    var id = $('#unitId').val();
    
    $.ajax({
        url: "/Unit/UnitDelete",
        data: { id: id },
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