window.siteFunction={
    InitDatePickerwithSelect: function (element, formatDate, minDate, maxDate) {

        $(element).datepicker('destroy');

        $(element).datepicker({

            showOtherMonths: true,

            selectOtherMonths: true,

            changeMonth: true,

            changeYear: true,

            dateFormat: formatDate,

            minDate: minDate == null ? null : new Date(minDate),

            maxDate: maxDate == null ? null : new Date(maxDate),

            onSelect: function (date) {

                var myElement = $(this)[0];

                var event = new Event('change');

                myElement.dispatchEvent(event);

            }

        });

    },

    SetMinMaxDate: function (element, minDate, maxDate) {

        var min = minDate == null ? null : new Date(minDate);

        var max = maxDate == null ? null : new Date(maxDate);

        $(element).datepicker('option', 'minDate', min);

        $(element).datepicker('option', 'maxDate', max);

    }
}