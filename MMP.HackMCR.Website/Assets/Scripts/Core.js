
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