
var openSoapBody = '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body>';
var closeSoapBody = '</soap:Body></soap:Envelope>';
var errors = 0;

function hasErrors() {
    return errors != 0;
}

function clearErrors() {
    errors = 0;
}

function checkEmpty(selector, errorSelector, errorMsg) {
    if (getValue(selector) == '') {
        setErrorMessage(errorSelector, errorMsg);
    }
    else {
        clearErrorMessage(errorSelector);
    }
}

function checkRegex(selector, regex, errorSelector, errorMsg) {
    var re = new RegExp(regex);

    if (!re.test(getValue(selector))) {
        setErrorMessage(errorSelector, errorMsg);
    }
    else {
        clearErrorMessage(errorSelector);
    }
}

function getValue(selector) {
    return $(selector).val();
}

function getText(selector) {
    return $(selector).text();
}

function setErrorMessage(selector, message) {
    if (getText(selector) == '') {
        $(selector).text(message);
        errors++;
    }
}

function clearErrorMessage(selector) {
    $(selector).text('');
}

function createSoapQuery(funcName, parameters) {
    var query = openSoapBody;
    query += '<' + funcName + ' xmlns="http://tempuri.org/">';

    if (parameters != null) {
        for (var key in parameters) {
            if (typeof(parameters[key]) != 'object') {
                query += '<' + key + '>' + parameters[key] + '</' + key + '>';
            }
            else {
                query += '<' + key + '>';

                for (var i = 0; i < parameters[key].length; i++) {
                    switch (typeof (parameters[key][i])) {
                        case 'number':
                            query += '<int>' + parameters[key][i] + '</int>';
                            break;
                    }
                }

                query += '</' + key + '>';
            }
        }
    }

    query += '</' + funcName + '>';
    query += closeSoapBody;
    return query;
}

function redirect(location) {
    window.location.href = location;
}