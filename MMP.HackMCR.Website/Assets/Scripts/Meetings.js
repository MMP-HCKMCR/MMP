
$(document).ready(function () {
    populate();
    bindEvents();
});

function populate() {
    var allUsersQuery = createSoapQuery('GetAllUsers', null);

    $.ajax({
        url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
        type: 'POST',
        data: allUsersQuery,
        contentType: 'text/xml; charset=utf-8',
        success: function (data) {
            console.log(data);
        },
        error: function (x, y, z) {
            console.log(z);
        }
    });
}

function bindEvents() {

}