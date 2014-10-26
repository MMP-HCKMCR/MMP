
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
    $('#CreateMeeting').bind('click', function (e) {
        createMeeting();
    });

    $('#FilterMeetingTimes').bind('click', function (e) {
        findMeetingTimes();
    });

    $('input[type=checkbox]').bind('change', function (e) {
        findMeetingTimes();
    });
}

function createMeeting() {
    clearErrors();

    checkEmpty('#MeetingName', '#NameError', 'Please enter a name for the meeting');
    checkEmpty('#MeetingDescription', '#DescriptionError', 'Please enter a description for the meeting');

    if (hasErrors()) {
        return;
    }

    var radio = $('input[type=radio]:checked');

    if (radio == null || radio.length == 0) {
        return;
    }

    var start = $(radio).parent().parent().find('.start').innerHTML;
    var end = $(radio).parent().parent().find('.end').innerHTML;
    var name = $('#MeetingName').val();
    var description = $('#MeetingDescription').val();
    
    var users = $('#UserChecklist input[type=checkbox]:checked').parent().find('label');
    var userIdArray = [];

    $(users).each(function () {
        userIdArray[userIdArray.length] = parseInt($(this).attr('data-userid'));
    });

    var query = createSoapQuery(
        'CreateMeeting',
        {
            userIds: userIdArray,
            summary: name,
            description: description,
            startTime: start,
            endTime: end
        });

    $.ajax({
        url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
        type: 'POST',
        data: query,
        contentType: 'text/xml; charset=utf-8',
        success: function (data, status, req) {
            console.log('SUCCESS');
        },
        error: function (x, y, z) {
            console.log(z);
        }
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

    $.ajax({
        url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
        type: 'POST',
        data: query,
        contentType: 'text/xml; charset=utf-8',
        success: function (data, status, req) {
            var table = $('#MeetingTimes').find('tbody');
            $(table).innerHTML = '';

            var times = $(req.responseXML).find('FindMeetingTimesResult').find('MeetingTime');
            var starts = times.find('StartTime');
            var ends = times.find('EndTime');

            var start = null;
            var end = null;

            for (var key in times) {
                if (starts[key].innerHTML == null) {
                    continue;
                }

                start = new Date(starts[key].innerHTML);
                end = new Date(ends[key].innerHTML);

                $(table).append('<tr><td><input type="radio" /></td><td class="start">' + start.toLocaleDateString() + ' ' + start.toLocaleTimeString() + '</td><td class="end">' + end.toLocaleDateString() + ' ' + end.toLocaleTimeString() + '</td></tr>');
            }
        },
        error: function (x, y, z) {
            console.log(z);
        }
    });
}