import { HandleTheErrors } from '../HandleTheErrors.js';

$('#addForm').submit(function (e) {

    var table = $('#table');

    var data = {
        Name: $('#addName').val(),
    }

    $.ajax({
        url: "/Category/CategoryAdd",
        data: data,
        type: "POST",
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                table.DataTable().ajax.reload();
                $('#addModal').modal('hide');
                $('#addForm').reset();
            }
        },
        error: function (error) {
            console.log("Hata :", error)
        }
    });

    e.preventDefault();
});