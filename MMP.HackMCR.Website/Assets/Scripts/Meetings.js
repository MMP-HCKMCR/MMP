
$(document).ready(function () {
    populate();
    bindEvents();
});

function populate() {
    //users
    var allUsersQuery = createSoapQuery('GetAllUsers', null);

    $.ajax({
        url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
        type: 'POST',
        data: allUsersQuery,
        contentType: 'text/xml; charset=utf-8',
        success: function (data, status, req) {
            var users = $(req.responseXML).find('GetAllUsersResult').find('User');
            var names = users.find('Name');
            var userIds = users.find('UserId');
            
            for (var key in names) {
                if (names[key].innerHTML == null) {
                    continue;
                }

                $('#UserChecklist').append('<div><input type="checkbox" /><label data-userId="' + userIds[key].innerHTML + '">' + names[key].innerHTML + '</label></div>');
            }
        },
        error: function (x, y, z) {
            console.log(z);
        }
    });

    //groups
    var allGroupsQuery = createSoapQuery('GetAllGroups', null);

    $.ajax({
        url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
        type: 'POST',
        data: allGroupsQuery,
        contentType: 'text/xml; charset=utf-8',
        success: function (data, status, req) {
            var groups = $(req.responseXML).find('GetAllGroupsResult').find('Group');
            var names = groups.find('GroupName');
            var groupIds = groups.find('GroupId');
            
            for (var key in names) {
                if (names[key].innerHTML == null) {
                    continue;
                }

                $('#GroupChecklist').append('<div><input type="checkbox" /><label data-groupId="' + groupIds[key].innerHTML + '">' + names[key].innerHTML + '</label></div>');
            }
        },
        error: function (x, y, z) {
            console.log(z);
        }
    });
}

function bindEvents() {
    $('input[type=checkbox]').bind('change', function (e) {

    });
}