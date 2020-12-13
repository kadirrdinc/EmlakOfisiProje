$(document).ready(function () {
    //jQuery.extend(jQuery.validator.messages, {
    //    required: '<span class="text-danger">Zorunlu Alan</span>',
    //    remote: "Please fix this field.",
    //    email: '<span class="text-danger">Doğru formatta email giriniz</span>',
    //    url: "Please enter a valid URL.",
    //    date: "Please enter a valid date.",
    //    dateISO: "Please enter a valid date (ISO).",
    //    number: "Please enter a valid number.",
    //    digits: "Please enter only digits.",
    //    creditcard: "Please enter a valid credit card number.",
    //    equalTo: "Please enter the same value again.",
    //    accept: "Please enter a value with a valid extension.",
    //    maxlength: jQuery.validator.format('<span class="text-danger">Maksimum değer aralığını aştınız</span>'),
    //    minlength: jQuery.validator.format("Please enter at least {0} characters."),
    //    rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
    //    range: jQuery.validator.format("Please enter a value between {0} and {1}."),
    //    max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
    //    min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
    //});

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "100",
        "hideDuration": "1000",
        "timeOut": "2000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

});