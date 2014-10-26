
$(document).ready(function () {
    bindEvents();
});


function bindEvents() {
    $('#RegisterButton').bind('click', function (e) {
        clearErrors();

        checkEmpty('#Email', '#EmailError', 'Please enter an email');
        checkEmpty('#UserDomain', '#UsernameError', 'Please enter a User Domain');
        checkEmpty('#Username', '#UsernameError', 'Please enter a Username');
        checkEmpty('#Password', '#PasswordError', 'Please enter a Password');
        checkEmpty('#FullName', '#NameError', 'Please enter your name');
        checkEmpty('#MobileNumber', '#MobileError', 'Please enter your mobile number');
        checkEmpty('#OneDiaryToken', '#TokenError', 'Please enter your One Diary Token');

        checkRegex('#Email', '^.*?@.+\..+$', '#EmailError', 'Please enter a valid email');
        checkRegex('#MobileNumber', '^[0-9]{1,11}$', '#MobileError', 'Please enter a valid mobile number');

        if (hasErrors()) {
            return;
        }

        var query = 'name=' + $('#FullName').val()
                  + '&userName=' + $('#UserDomain').val() + "/" + $('#Username').val()
                  + '&token=' + $('#OneDiaryToken').val()
                  + '&mobileNumber=' + $('#MobileNumber').val()
                  + '&password' + $('#Password').val()
                  + '&emailAddress' + $('#Email').val();

        $.ajax({
            url: 'http://hackmsrweb.cloudapp.net/MMPWebService.asmx/AddUser',
            type: 'GET',
            data: query,
            dataType: 'xml',
            success: function (data) {
                //direct to home page
                setErrorMessage('#GeneralError', 'SUCCESS!');
            },
            error: function(x, y, z) {
                setErrorMessage('#GeneralError', x + '\n' + y + '\n' + z);
            }
        });
    });
}