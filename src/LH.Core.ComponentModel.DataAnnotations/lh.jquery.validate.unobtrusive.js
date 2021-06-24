/**
 * Required if custom validator
 */
$.validator.addMethod("requirediftrue", function (value, element, params) {
    let dependentValue = $('input[name*="' + params.property + '"]:checked').val();

    let valid = true;
    if (dependentValue == "true" && (value == "" || value == null)) {
        valid = false;
    }

    return valid;
});

$.validator.unobtrusive.adapters.add("requirediftrue", ["property"], function (options) {
    options.rules["requirediftrue"] = {
        property: options.params.property
    };
    options.messages["requirediftrue"] = options.message;
});

/**
 * Past date custom validator
 */
$.validator.addMethod("pastdate", function (value, element, params) {
    let now = Date.now();
    let enteredDate = Date.parse(value);

    if (isNaN(enteredDate)) {
        return false;
    }

    return (enteredDate > now) ? false : true;
});

$.validator.unobtrusive.adapters.add("pastdate", function (options) {
    options.rules["pastdate"] = options.params;
    options.messages["pastdate"] = options.message;
});

/**
 * Future date custom validator
 */
$.validator.addMethod("futuredate", function (value, element, params) {
    let now = Date.now();
    let enteredDate = Date.parse(value);

    if (isNaN(enteredDate)) {
        return false;
    }

    return (enteredDate < now) ? false : true;
});

$.validator.unobtrusive.adapters.add("futuredate", function (options) {
    options.rules["futuredate"] = options.params;
    options.messages["futuredate"] = options.message;
});