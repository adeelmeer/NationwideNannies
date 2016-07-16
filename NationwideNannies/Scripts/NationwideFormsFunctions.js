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
                changeYear: true,
                yearRange: "-100:+10"
            });

            $('#PreferedPosition').change(function () {
                var ddlbPreferedPosition = $(this);
                var currentValue = ddlbPreferedPosition.val();

                var data = [];
                if (currentValue == "Nanny") {
                    data = ["Live in", "Live out", "Nanny/Mother’s helper", "Nanny house keeper"];
                }
                else if (currentValue == "Maternity/Night nurse") {
                    data = ["Maternity nurse", "Night nurse"];
                }
                else {
                    data = ["Day time", "Evening/Weekends", "Any"];
                }

                var ddlbJobType = $("#JobType");
                ddlbJobType.empty();

                $.each(data, function (index, item) {
                    ddlbJobType.append(
                       $('<option>', {
                           value: item,
                           text: item
                       }, '</option>'));

                });

            }).change();

            $('#HaveDBS').change(function () {
                var ddlb = $(this);
                var currentValue = ddlb.val();
                if (currentValue == "Yes") {
                    $('#DBSDate').attr('required', 'required');
                }
                else {
                    $('#DBSDate').removeAttr('required');
                }
            });

            $('#IsLiveInEveningBabbySitting').change(function () {
                var ddlb = $(this);
                var currentValue = ddlb.val();
                if (currentValue == "Yes") {
                    $('#EveningBabaySittingPerWeek').attr('required', 'required');
                }
                else {
                    $('#EveningBabaySittingPerWeek').removeAttr('required');
                }
            });

            $('#LiveInOut').change(function () {
                var ddlb = $(this);
                var currentValue = ddlb.val();
                if (currentValue == "Live in") {
                    $('#IsLiveInEveningBabbySitting').attr('required', 'required');
                }
                else {
                    $('#IsLiveInEveningBabbySitting').removeAttr('required');
                }
            });

            $('#HaveChildcareQualification').change(function () {
                var ddlb = $(this);                
                var currentValue = ddlb.val();
                if (currentValue == "Yes") {
                    $('#ChildcareQualificationDetails').attr('required', 'required');
                }
                else {
                    $('#ChildcareQualificationDetails').removeAttr('required');
                }
            });
            
        }

    };
}($));
