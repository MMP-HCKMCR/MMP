
$(document).ready(function () {
    bindEvents();
});

function bindEvents() {
    $('#LoginButton').bind('click', function (e) {
        clearErrors();

        checkEmpty('#Email', '#EmailError', 'Please enter an email');
        checkEmpty('#Password', '#PasswordError', 'Please enter a Password');

        checkRegex('#Email', '^.*?@.+\..+$', '#EmailError', 'Please enter a valid email');

        if (hasErrors()) {
            return;
        }

        var query = createSoapQuery(
            'LoginUser',
            {
                email: $('#Email').val(),
                password: $('#Password').val()
            });

        $.ajax({
            url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
            type: 'POST',
            data: query,
            contentType: 'text/xml; charset=utf-8',
            success: function (data) {
                if (data.guid != '') {
                    redirect('Meetings.aspx?Guid=' + data.guid);
                }
                else {
                    setErrorMessage('#GeneralError', 'Login failed');
                }
            },
            error: function (x, y, z) {
                setErrorMessage('#GeneralError', z);
            }
        });
    });
}