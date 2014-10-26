
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
    $('#FilterMeetingTimes').bind('click', function (e) {
        findMeetingTimes();
    });

    $('input[type=checkbox]').bind('change', function (e) {
        findMeetingTimes();
    });
}

function findMeetingTimes() {
    var users = $('#UserChecklist input[type=checkbox]:checked').parent().find('label');
    var userIdArray = [];

    $(users).each(function() {
        userIdArray[userIdArray.length] = parseInt($(this).attr('data-userid'));
    });

    var groups = $('#GroupChecklist input[type=checkbox]:checked').parent().find('label');
    var groupIdArray = [];

    $(groups).each(function() {
        groupIdArray[groupIdArray.length] = parseInt($(this).attr('data-groupid'));
    });

    var query = createSoapQuery(
        'FindMeetingTimes',
        {
            userIds: userIdArray,
            groupIds: groupIdArray,
            duration: $('#MeetingDuration :selected').text(),
            startDate: $('#MeetingStartDate').val() + ' ' + $('#MeetingStartTime').val() + ':00.000',
            endDate: $('#MeetingEndDate').val() + ' ' + $('#MeetingEndTime').val() + ':00.000'
        });

    console.log(query);

    $.ajax({
        url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
        type: 'POST',
        data: query,
        contentType: 'text/xml; charset=utf-8',
        success: function (data, status, req) {
            console.log(req.responseXML);
            /*var groups = $(req.responseXML).find('GetAllGroupsResult').find('Group');
            var names = groups.find('GroupName');
            var groupIds = groups.find('GroupId');

            for (var key in names) {
                if (names[key].innerHTML == null) {
                    continue;
                }

                $('#GroupChecklist').append('<div><input type="checkbox" /><label data-groupId="' + groupIds[key].innerHTML + '">' + names[key].innerHTML + '</label></div>');
            }*/
        },
        error: function (x, y, z) {
            console.log(z);
        }
    });
}