import { HandleTheErrors } from "../HandleTheErrors.js";

$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var productId = button.data('id') // Extract info from data-* attributes

    $.ajax({
        url: '/StockedProduct/StockProductById/',
        type: 'GET',
        data: { stockProductId: productId },
        success: function (response) {
            $('#stockedProductId').val(response.id);
            $('#strongName').html(response.name);
        },
        error: function (response) {
            console.log("Hata :", response);
        }
    });

});