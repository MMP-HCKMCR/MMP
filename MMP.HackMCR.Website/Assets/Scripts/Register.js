
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

        var query = createSoapQuery(
            'AddUser',
            {
                name: $('#FullName').val(),
                userName: $('#UserDomain').val() + "/" + $('#Username').val(),
                token: $('#OneDiaryToken').val(),
                mobileNumber: $('#MobileNumber').val(),
                password: $('#Password').val(),
                emailAddress: $('#Email').val()
            });

        $.ajax({
            url: 'http://hackmsrweb.cloudapp.net/WebService/MMPService.asmx',
            type: 'POST',
            data: query,
            contentType: 'text/xml; charset=utf-8',
            success: function (data) {
                $('.overlay').show();
                $('#RegisterSuccess').show();
            },
            error: function(x, y, z) {
                setErrorMessage('#GeneralError', z);
            }
        });
    });
}