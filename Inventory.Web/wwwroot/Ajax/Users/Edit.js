import { HandleTheErrors } from '../HandleTheErrors.js';

$('#editForm').submit(function (e) {
    var data = {
        Id: $('#userId').val(),
        UserName: $('#userName').val(),
        Email: $('#email').val(),
        PhoneNumber: $('#phoneNumber').val(),
        Password: $('#password').val(),
        PasswordConfirm: $('#passwordConfirm').val(),
        roleId: $('#role').val(),
    }

    $.ajax({
        url: "/User/EditJson",
        type: "POST",
        data: data,
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                window.location.href = "/Panel/Users";
            }
        },
        error: function (error) {
            console.log("Hata :", error);
        }
    });

    e.preventDefault();

});