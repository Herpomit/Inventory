import { HandleTheErrors } from "../HandleTheErrors.js";

$('#editModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var unitId = button.data('id');
    
    $.ajax({
        url: "/Unit/UnitGetById",
        data: { id: unitId },
        type: "GET",
        success: function (response) {
            $('#editName').val(response.name);
            $('#editCode').val(response.code);
            $('#unitId').val(response.id);
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });
});

$('#editForm').submit(function (e) {

    var table = $('#table');

    var data = {
        Id: $('#unitId').val(),
        Name: $('#editName').val(),
        Code: $('#editCode').val()
    };

    $.ajax({
        url: "/Unit/UnitEdit",
        data: data,
        type: "POST",
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors  == null) {
                table.DataTable().ajax.reload();
                $('#editModal').modal('hide');
                $('#editForm').trigger("reset");
            }
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

    e.preventDefault();

});