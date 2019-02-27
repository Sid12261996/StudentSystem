$(document).ready(function () {

    var countryCode = $('#countryCode');

    $.ajax({
        type: 'GET',
        url: 'https://restcountries.eu/rest/v2/all',
       // dataType: "json",
        //applicationHeader: "bearer",
        //contentType: "application/json",
        success: function (data) {

            countryCode.append("<option>" + "India" + " " + "+91" + "</option>");

            $.each(data, function (Index, item) {
                var countrycallingCode = item.callingCodes;
                var abbr = item.name;
                countryCode.append("<option>" +abbr +" " + countrycallingCode+"</option>");
                    });
        }

        });


});