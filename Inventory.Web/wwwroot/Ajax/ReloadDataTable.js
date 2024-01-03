function reloadDataTable() {
    $('#table').DataTable().ajax.reload();
    iziToast.success({ timeout: 5000, icon: 'fa-solid fa-check', position: 'bottomRight', title: 'Yenilendi', message: 'Başarılı bir şekilde yenilendi!' });
}