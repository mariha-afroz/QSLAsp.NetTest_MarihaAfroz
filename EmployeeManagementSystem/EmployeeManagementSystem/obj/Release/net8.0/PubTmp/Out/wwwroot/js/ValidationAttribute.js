
$.validator.addMethod("isNotRequired", function (value, element, params) {

    IsNotRequired = document.getElementById(element.getAttribute("data-val-propertyName")).checked;

    if ((value == "" && IsNotRequired == null) || (IsNotRequired == false && value == "")) {
        return false;
    }

    return true;
});

$.validator.unobtrusive.adapters.add("isNotRequired", function (options) {
    options.rules["isNotRequired"] = true;

    if (options.message) {
        options.messages["isNotRequired"] = options.message;
    }

});


// Validation Method for Future Date Script
$.validator.addMethod("isfuturedate", function (value, element, params) {
    if (value != null) {
        var selectedDate = Date.parse( value );

        if ( isNaN(selectedDate) )
        {
            return true;
        }

        var currentDate = new Date();

        return selectedDate <= currentDate;
    }

    return true;
});

// Unobtrusive Adapter for Future Date Script
$.validator.unobtrusive.adapters.add("isfuturedate", function (options) {
    options.rules["isfuturedate"] = true;

    if (options.message) {
        options.messages["isfuturedate"] = options.message;
    }

});

//---------------------------------------------------------------------------------------------
//To Date not Grater than From Date
// Example =>  [ToDateAttribute("DetainFromDate", ErrorMessage = "To Detain Date is not allowed to be before Detain Start Date")]
//----------------------------------------------------------------------------------------------
//
// Validation Method for To Date > From Date Script
$.validator.addMethod("toDate", function (value, element, params) {
    if (value != null) {
        var selectedDate = Date.parse(value);
        fromDate = Date.parse(document.getElementById(element.getAttribute("data-val-fromdate")).value);

        return fromDate < selectedDate;
    }

    return true;
});

// Unobtrusive Adapter for To Date > From Date Script
$.validator.unobtrusive.adapters.add("toDate", function (options) {
    options.rules["toDate"] = true;

    if (options.message) {
        options.messages["toDate"] = options.message;
    }

});

//---------------------------------------------------------------------------------------------
// Date Difference Comparison
// Example =>  
//----------------------------------------------------------------------------------------------
//
// Validation Method for RequiredIfAttribute Script
$.validator.addMethod("isDateDifferenceComparison", function (value, element, params) {

        if (value != null) {
        var selectedDate = new Date(value);

        startDate = new Date(document.getElementById(element.getAttribute("data-val-propertyName")).value);

        validationValue = element.getAttribute("data-val-validationValue");

        var months;
        months = (selectedDate.getFullYear() - startDate.getFullYear()) * 12;
        months -= startDate.getMonth();
        months += selectedDate.getMonth();

        console.log('months', months);

        if (months > validationValue) {
            return false;
        }
    
    }
        return true;
});

// Unobtrusive Adapter for Future Date Script
$.validator.unobtrusive.adapters.add("isDateDifferenceComparison", function (options) {
options.rules["isDateDifferenceComparison"] = true;

if (options.message) {
    options.messages["isDateDifferenceComparison"] = options.message;
}

});
