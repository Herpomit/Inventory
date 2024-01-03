import { HandleTheErrors } from "../HandleTheErrors.js";

$("#loginForm").submit(function (e) {
    var data = {
        Email: $("#loginEmail").val(),
        Password: $("#loginPassword").val(),
        RememberMe: $("#rememberMe").is(":checked")
    }
    console.log(data);
    $.ajax({
        url: "/Member/Login",
        type: "POST",
        data: data,
        success: function (response) {
            HandleTheErrors(response);
            if (response.errors == null) {
                setTimeout(function () {
                    window.location.href = "/Panel/Index";
                }, 2500);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });

    e.preventDefault();
});