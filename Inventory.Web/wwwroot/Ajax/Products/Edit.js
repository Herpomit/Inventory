import { HandleTheErrors } from "../HandleTheErrors.js";

$('#editForm').submit(function (e) {
    var data = {
        Id: $('#productId').val(),
        Name: $('#editName').val(),
        categoryIds: $('#editCategories').val(),
    };

    $.ajax({
        url: '/Product/Edit',
        type: 'POST',
        data: data,
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                setTimeout(function () {
                    window.location.href = "/Panel/Products";
                }, 2500);
            };
        },
        error: function (response) {
            console.log("Hata :", response);
        }
    });
    e.preventDefault();
});