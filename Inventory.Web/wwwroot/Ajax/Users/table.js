function Dropdown(data) {
    // data parametresi ile id'yi alıyoruz
    return `
    <div class="dropdown">
        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
        Action
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <li><a class="dropdown-item" href="/Panel/UserEdit/${data}">Güncelle</a></li>
            <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#deleteModal" data-id="${data}">Sil</a></li>
        </ul>
    `;

}


$(document).ready(function () {

    var userHasSorted = false;

    var table = $('#table').DataTable({
        "preDrawCallback": function (settings) {
            var api = new $.fn.dataTable.Api(settings);
            if (!userHasSorted) {
                api.order([]); // Başlangıçta sıralama yapılmamasını sağlar
            }
        },
        "ajax": {
            "url": "/User/UserTable",
            "type": "POST",
            "dataType": "json",
            "data": function (d) {
                if (userHasSorted) {
                    d.orderColumnIndex = d.order[0].column;
                    d.orderColumnName = d.columns[d.orderColumnIndex].data;
                    d.orderDir = d.order[0].dir;
                }

            }
        },
        "rowId": 'id',
        "columns": [
            { data: "userName" },
            { data: "email" },
            { data: "phoneNumber" },
            { data: "id", render: Dropdown, "orderable": false, "searchable": false, "width": "150px" },
        ],
        "language": {
            url: "/Ajax/languagev2.json"
        },
        "draw": 1,
        "processing": true,
        "serverSide": true,
        "searchable": true,
        "search": {
            "value": "my search value",
            "regex": false
        },
        "stateSave": true,
        "pageLength": 25,
    });

    table.on('click', 'th', function () {
        userHasSorted = true;
    });
});