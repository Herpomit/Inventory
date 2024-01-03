export function HandleTheErrors(response) {
    var errors = response.errors;
    if (errors != null) {
        for (var key in errors) {
            if (response.errors.hasOwnProperty(key)) {
                var fieldErrors = response.errors[key].errors;
                for (let i = 0; i < fieldErrors.length; i++) {
                    return iziToast.error({
                        timeout: 2500,
                        title: 'Hata!',
                        icon: 'fa fa-exclamation-triangle',
                        message: fieldErrors[i].errorMessage,
                    })
                }
            }
        }
    }

    return iziToast.success({
        timeout: 2500,
        title: 'Başarılı!',
        icon: 'fa fa-check',
        message: response,
    });
}