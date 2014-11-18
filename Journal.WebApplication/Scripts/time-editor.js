$(document).ready(function () {

    var currentTime = moment ();

    //$.getJSON("Api/GetCurrentTime", function (data) {
    //    currentTime = data.time;
    //});

    setInterval(function() {
        currentTime = currentTime.add('minutes', 1);
        $(".time-editor").val(currentTime.format("HH:mm"));
    }, 1000);

    $(".time-editor").inputmask("hh:mm", {
        "placeholder": " ",
        "onincomplete": function () { $(".time-editor").val("03:03"); }
    });
});