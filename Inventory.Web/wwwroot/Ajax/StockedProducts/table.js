function DropDown(data) {
    
        return `
        <div class="dropdown">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
            Action
            </button>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#editModal" data-id="${data}">Edit</a></li>
                <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#deleteModal" data-id="${data}">Delete</a></li>
            </ul>
        `;
    
    }

$(document).ready(function () {

    var table = $('#table').DataTable({
        "ajax": "/StockedProduct/StockProductTable",
        "columns": [
            { "data": "stockedProduct.product.name" },
            { "data": "stockedProduct.stock" },
            {
                "data": "stockedProductUnits", render: function (data) {

                    var weights = [];
                    for (var i = 0; i < data.length; i++) {
                        var formattedWeight = data[i].weight.toLocaleString('tr-TR', { minimumFractionDigits: 2 });
                        weights.push(data[i].unit.name + " (" + formattedWeight + ")");
                    }
                    return weights.join(", ");
                }
            },
            { "data": "stockedProduct.createdAt" },
            { "data": "stockedProduct.updatedAt" },
            { "data": "stockedProduct.Id", render: DropDown },
        ],
        columnDefs: [
            { targets : 2 , style: "width: 200px"}
        ],
        "language": {
            url: "/Ajax/languagev2.json"
        },
    });
});