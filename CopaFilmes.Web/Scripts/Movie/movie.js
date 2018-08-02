$(document).ready(function () {
    $(".countCheckBox").click(function (e) {
        var checados = [];
        $.each($("input[id='chkOption[]']:checked"), function () {
            checados.push($(this).val());
        });

        $('#txtCount').html(checados.length);

        if (checados.length == 16) {
            $('#btnGerarMeuCampeonato').prop("hidden", false);
        }
        else {
            $('#btnGerarMeuCampeonato').prop("hidden", true);
        }
    });
});