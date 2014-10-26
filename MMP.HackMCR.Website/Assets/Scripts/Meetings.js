﻿
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
            var names = $(req.responseXML).find('GetAllUsersResult').find('User').find('Name');
            
            for (var key in names) {
                if (names[key].innerHTML == null) {
                    continue;
                }

                $('#UserChecklist').append('<div><input type="checkbox" /><label>' + names[key].innerHTML + '</label></div>');
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
            var names = $(req.responseXML).find('GetAllGroupsResult').find('Group').find('GroupName');
            
            for (var key in names) {
                if (names[key].innerHTML == null) {
                    continue;
                }

                $('#GroupChecklist').append('<div><input type="checkbox" /><label>' + names[key].innerHTML + '</label></div>');
            }
        },
        error: function (x, y, z) {
            console.log(z);
        }
    });
}

function bindEvents() {

}