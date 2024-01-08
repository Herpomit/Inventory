import { HandleTheErrors } from '../HandleTheErrors.js';

$('#addForm').submit(function (e) {
    var table = $('#table');

    var data = {
        Name: $('#addName').val(),
        categoryIds: $('#addCategories').val(),
    };

    $.ajax({
        url: '/Product/Add',
        type: 'POST',
        data: data,
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                $('#addForm').trigger('reset');
                $('#addModal').modal('hide');
                table.DataTable().ajax.reload();
            }
        },
        error: function (response) {
            console.log("Hata :", responseF);
        }
    });

    e.preventDefault();
});