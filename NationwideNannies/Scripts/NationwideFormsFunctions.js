(function ($) {
    window.NationwideFormsFunctions = {
    

        initialize: function () {

            $(".date-field").keydown(function (e) {
                e.preventDefault();
            });

            $(".date-field").datepicker({
                dateFormat: "dd MM yy",
                showAnim: "slideDown",
                changeMonth: true,
                changeYear: true
            });

        }

    };
}($));
